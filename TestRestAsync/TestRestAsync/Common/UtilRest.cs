using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRestAsync.Implementation;
using TestRestAsync.Enums;
//using Newtonsoft.Json;
using System.Reflection;
using System.Net;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace TestRestAsync.Common
{
    public static class UtilRest
    {
        public static ResponseRestDM<TResultado> InvocaServicioRest<TResultado>
                                                    (string url, string element)
        {
            var respuesta = new ResponseRestDM<TResultado>() { };
            ResponseDMCashdroEnum resCodigo = 0;
            TResultado resultado = default(TResultado);
            dynamic resData;
            string sError = "";

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            SimpleObjectDictionaryMapper<TResultado> map = new SimpleObjectDictionaryMapper<TResultado>();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                var responses = (HttpWebResponse)request.GetResponse();
                var response = new StreamReader(responses.GetResponseStream()).ReadToEnd();
                PropertyInfo[] props = typeof(TResultado).GetProperties();
                JavaScriptSerializer js = new JavaScriptSerializer();
                //resultado = js.Deserialize<TResultado>(response);
                var res = js.Deserialize<dynamic>(response);
                resCodigo = (ResponseDMCashdroEnum)res["code"];

                if (resCodigo != ResponseDMCashdroEnum.OK)
                {
                    sError = res["data"];
                    resData = null;
                }
                else
                {
                    if ((res["data"].GetType() == typeof(System.Collections.Generic.Dictionary<string, object>)) || (res["data"].GetType() == typeof(string)) || (res["data"].GetType() == typeof(int)))
                    {
                        resData = js.Deserialize<dynamic>(res["data"]);
                    }
                    else
                    {
                        resData = null;
                        resCodigo = ResponseDMCashdroEnum.ERROR;
                    }
                }

                if (resData != null && resCodigo == ResponseDMCashdroEnum.OK)
                {
                    sError = "";

                    if (resData.GetType() == typeof(System.Collections.Generic.Dictionary<string, object>))
                    {
                        ////Barrido por cada elemento del Diccionario principal
                        foreach (KeyValuePair<string, object> entry in resData)
                        {
                            // do something with entry.Value or entry.Key
                            //Evaluo el tipo de objeto contenido en el diccionario principal
                            //Primero evaluo si es diccionario
                            if (entry.Key.ToString() == element && entry.Value.GetType() == typeof(System.Collections.Generic.Dictionary<string, object>))
                            {
                                var dic = (IDictionary<string, object>)entry.Value;
                                //Evaluo que el objeto que deseo retornar tenga la misma cantidad de items que el diccionario
                                //Para asegurar que se evalua el objeto correcto
                                resultado = map.GetObject(dic);
                            }
                        }
                    }
                    else if (resData.GetType() == typeof(int))
                    {
                        resultado = resData;
                    }
                }
            }
            catch (TimeoutException ex)
            {
                respuesta.Codigo = ResponseDMCashdroEnum.FATAL;
                respuesta.Mensaje = "Fallo de Tiempo Excedido: " + ex.Message;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Codigo = ResponseDMCashdroEnum.FATAL;
                respuesta.Mensaje = "Fallo General: " + ex.Message;
                return respuesta;
            }

            respuesta.Codigo = resCodigo;
            respuesta.Mensaje = sError;
            respuesta.Data = resultado;
            return respuesta;
        }

        public static ResponseListRestDM<TResultado> InvocaServicioListRest<TResultado>
                                            (string url, string element)
        {
            var respuesta = new ResponseListRestDM<TResultado>() { };
            ResponseDMCashdroEnum resCodigo = 0;
            List<TResultado> resultadoLst = new List<TResultado>();
            dynamic resData;
            string sError = "";

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            SimpleObjectDictionaryMapper<TResultado> map = new SimpleObjectDictionaryMapper<TResultado>();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                var responses = (HttpWebResponse)request.GetResponse();
                var response = new StreamReader(responses.GetResponseStream()).ReadToEnd();
                PropertyInfo[] props = typeof(TResultado).GetProperties();
                JavaScriptSerializer js = new JavaScriptSerializer();
                //resultado = js.Deserialize<TResultado>(response);
                var res = js.Deserialize<dynamic>(response);
                resCodigo = (ResponseDMCashdroEnum)res["code"];

                if (resCodigo != ResponseDMCashdroEnum.OK)
                {
                    sError = res["data"];
                    resData = null;
                }
                else
                {
                    //resData = js.Deserialize<dynamic>(res["data"]);
                    if ((res["data"].GetType() == typeof(string)) || (res["data"].GetType() == typeof(int)))
                    {
                        resData = js.Deserialize<dynamic>(res["data"]);
                    }
                    else if (res["data"].GetType() == typeof(object[]))
                    {
                        resData = res["data"];
                    }
                    else
                    {
                        resData = null;
                        resCodigo = ResponseDMCashdroEnum.ERROR;
                    }
                }

                if (resData != null && resCodigo == ResponseDMCashdroEnum.OK)
                {
                    sError = "";

                    if (resData.GetType() == typeof(System.Collections.Generic.Dictionary<string, object>))
                    {
                        ////Barrido por cada elemento del Diccionario principal
                        foreach (KeyValuePair<string, object> entry in resData)
                        {
                            // do something with entry.Value or entry.Key
                            //Evaluo el tipo de objeto contenido en el diccionario principal
                            //Primero evaluo si es diccionario
                            if ((entry.Key.ToString() == element) && entry.Value.GetType() == typeof(object[]))
                            {
                                resultadoLst = map.GetListObject(entry.Value);
                            }
                        }
                    }
                    else if (resData.GetType() == typeof(object[]))
                    {
                        ////Barrido por cada elemento del Diccionario principal
                        resultadoLst = map.GetListObject(resData);
                    }
                }
            }
            catch (TimeoutException ex)
            {
                respuesta.Codigo = ResponseDMCashdroEnum.FATAL;
                respuesta.Mensaje = "Fallo de Tiempo Excedido: " + ex.Message;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Codigo = ResponseDMCashdroEnum.FATAL;
                respuesta.Mensaje = "Fallo General: " + ex.Message;
                return respuesta;
            }

            respuesta.Codigo = resCodigo;
            respuesta.Mensaje = sError;
            respuesta.Data = resultadoLst;
            return respuesta;
        }

    }

    class SimpleObjectDictionaryMapper<TObject>
    {

        public TObject GetObject(IDictionary<string, object> dic)
        {
            //Propiedades del objeto evaluado
            PropertyInfo[] props = typeof(TObject).GetProperties();
            TObject res = Activator.CreateInstance<TObject>();
            ////Barrido por cada elemento del Diccionario principal
            for (int i = 0; i < props.Length; i++)
            {

                if (props[i].CanWrite && dic.ContainsKey(props[i].Name.ToLower()))
                {
                    if (dic[props[i].Name.ToLower()] != null)
                        props[i].SetValue(res, dic[props[i].Name.ToLower()].ToString(), null);
                }
                else if (props[i].CanWrite && dic.ContainsKey(props[i].Name.ToUpper()))
                {
                    if (dic[props[i].Name.ToUpper()] != null)
                        props[i].SetValue(res, dic[props[i].Name.ToUpper()].ToString(), null);
                }
                else if (props[i].CanWrite && dic.ContainsKey(props[i].Name))
                {
                    if (dic[props[i].Name] != null)
                        props[i].SetValue(res, dic[props[i].Name].ToString(), null);
                }
            }
            return res;
        }

        public List<TObject> GetListObject(dynamic d)
        {
            Type typeOft = typeof(TObject);
            PropertyInfo[] props = typeof(TObject).GetProperties();
            List<TObject> list = new List<TObject>();
            foreach (dynamic item in d)
            {
                // check if the value is not null or empty.
                if (item != null)
                {
                    //Seteo un nuevo objeto
                    TObject resObj = Activator.CreateInstance<TObject>();
                    //Transformo el Item en un diccionario
                    var dic = (IDictionary<string, object>)item;
                    //Proceso el valor
                    for (int i = 0; i < props.Length; i++)
                    {
                        if (props[i].CanWrite && dic.ContainsKey(props[i].Name.ToLower()))
                        {
                            if (dic[props[i].Name.ToLower()] != null)
                                props[i].SetValue(resObj, dic[props[i].Name.ToLower()].ToString(), null);
                        }
                        else if (props[i].CanWrite && dic.ContainsKey(props[i].Name.ToUpper()))
                        {
                            if (dic[props[i].Name.ToUpper()] != null)
                                props[i].SetValue(resObj, dic[props[i].Name.ToUpper()].ToString(), null);
                        }
                        else if (props[i].CanWrite && dic.ContainsKey(props[i].Name))
                        {
                            if (dic[props[i].Name] != null)
                                props[i].SetValue(resObj, dic[props[i].Name].ToString(), null);
                        }
                    }
                    //Inserto el nuevo objeto en la lista.
                    list.Add(resObj);
                }
            }
            return list;
        }


        public TObject GetObjectDictionary(IDictionary<string, object> d)
        {
            PropertyInfo[] props = typeof(TObject).GetProperties();
            TObject res = Activator.CreateInstance<TObject>();
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].CanWrite && d.ContainsKey(props[i].Name.ToLower()))
                {
                    props[i].SetValue(res, d[props[i].Name.ToLower()], null);
                }
            }
            return res;
        }

        public IDictionary<string, object> GetDictionary(TObject o)
        {
            IDictionary<string, object> res = new Dictionary<string, object>();
            PropertyInfo[] props = typeof(TObject).GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].CanRead)
                {
                    res.Add(props[i].Name, props[i].GetValue(o, null));
                }
            }
            return res;
        }
    }
}
