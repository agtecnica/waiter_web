using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public static class Genericos
    {
        /// <summary>
        /// Carrega um objeto do tipo genérico
        /// </summary>
        /// <typeparam name="T">Tipo genérico</typeparam>
        /// <param name="dataTable">Recebe um objto carregado do tipo DataTable</param>
        /// <param name="row">Recebe qual linha (Tipo int) do DataTable será carregada</param>
        /// <returns></returns>
        public static T Popular<T>(DataTable dataTable, int row)
        {



            //"Pegamos" o tipo de T, para termos acessos as propriedades e valores.
            Type classType = typeof(T);

            //Cria uma nova instância do Tipo T
            T newClass = (T)Activator.CreateInstance(classType);

            //Pegamos as propriedades da entidade.
            PropertyInfo[] propriedades = classType.GetProperties();

            int itemArray = 0;
            foreach (var item in propriedades)
            {
                //Pega o tipo da respectiva propriedade do objeto
                PropertyInfo propertySet = classType.GetProperty(item.Name);

                bool isRelationchip = !(item.GetMethod).Attributes.ToString().Contains("Virtual");

                //Type t = typeof();

                //Seta o valor respectivo da propriedade
                if (itemArray < dataTable.Rows[row].ItemArray.Count())
                    if (dataTable.Rows[row].ItemArray[itemArray].ToString() != "")
                        if (isRelationchip)
                            propertySet.SetValue(newClass, dataTable.Rows[row].ItemArray[itemArray], null);

                propertySet.GetValue(newClass, null);
                itemArray++;
            }

            return newClass;
        }
    }
}
