using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    class User
    {
        private int[] userPermissions;

        public User(int userId)
        {
            userPermissions = DbManager.dbGetIntArray("SELECT idFuncionalidad FROM ENER_LAND.FUNCIONALIDAD").intArrayValue;
        }

        public int[] getUserPermissions()
        {
            return this.userPermissions;
        }
    }
}
