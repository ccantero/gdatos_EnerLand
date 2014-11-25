using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    class User
    {
        private int[] userPermissions;

        public User(int userId, int RolId)
        {
            userPermissions = DbManager.dbGetIntArray("SELECT x1.idFuncionalidad " +
                                                      "FROM ENER_LAND.Rol_Funcionalidad x1, ENER_LAND.Rol_Usuario x2 " +
                                                      "WHERE x1.idRol = x2.idRol " +
                                                      "AND x2.idRol = " + RolId.ToString() +
                                                      "AND x2.idUsuario = " + userId.ToString()).intArrayValue;
        }

        public int[] getUserPermissions()
        {
            return this.userPermissions;
        }
    }
}
