using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PSOO.IDAO;

namespace PSOO.App
{
    public class Configuracao : IConexao
    {
        public string ConnectionString => throw new NotImplementedException();

        public string DedaultSchemaDB => throw new NotImplementedException();
    }
}