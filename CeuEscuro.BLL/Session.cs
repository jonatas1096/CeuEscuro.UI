using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.BLL
{
    public static class Session
    {
		private static string userName;

		public static string userSession
		{
			get { return userName; }
			set { userName = value; }
		}

	}
}
