/*
 * IAuthServer.cs
 * Authentication Server Interface (service contract) for Client API
 * 
 */
/*
 * Depend files
 * ======================
 * None.
 * 
 * Maintanence
 * ======================
 * 10/13/2011 - first release.
 */
using System.Collections.Generic;
using System.ServiceModel;

namespace edu.syr.cse784.eskimodb.sharedobjs
{
    [ServiceContract]
    public interface IAuthServer
    {
  
            /*
             * CreateUser() creates a new user for the DB, with the given name and password.
             * To successfully create the new user, current user needs to provide their username
             * and password, and the current user's role needs to be administrator.
             * @param userName is the user name of current user.
             * @param pwd is the password of current user.
             * @param newUser is the username of the user to be created.
             * @param newUserPwd is the password of the user to be created.
             * @returns the result of create user operation and related info.
             */
            [OperationContract]
            AuthResult CreateUser(string newUser, string newUserPwd, string token);


            /*
         * IsAdmin() verifies whetherthe current user is administrator or not
         * @param auth_token is the current user's auth_token
         * @returns the whether or not the current user is admin
         */
            [OperationContract]
            bool IsAdmin(string auth_token);

            /*
             * Authenticate() verifies whether a user is allowed to use the DB by checking 
             * their username/password pair. if the pair is valid then the function will
             * generate an authentication token for the user and gives the token back to the user.
             * User don't need to be authenticated again for a certain period when they interact
             * with the DB. If the check doesn't pass the token will be set to empty string "".
             * @param userName is the user name of the user to be checked.
             * @param pwd is the password of the user to be checked.
             * @param token is the string to store the authentication token.
             * @returns the result of authentication operation and related info.
             */
            [OperationContract]
            AuthResult Authenticate(string userName, string pwd, out string token);


            /*
            * GetAllUserNames() get all the existing user names
            * @returns a string list containing all the existing user names
            * @param token is the current user's token
            */
            [OperationContract]
            List<string> GetAllUserNames(string token);

            /*
             * ChangeUserPrivilege() tells the auth server to change specific user's privilege level(regular or administrator)
             * @param userName is the user name whose privilege level will be changed
             * @param adminstrator is the privilege level(true administrator, false regular)
             * @param token is the current user's token
             * @returns the result of  operation and related info
             */
            [OperationContract]
            AuthResult ChangeUserPrivilege(string userName, bool administrator, string token);

            /*
            * ChangePassword() tells the auth server to change the password of specific user
            * @param userName is the user name whosepassword is going to be changed
            * @param pwd is the changed password
            * @param token is the current user's token
            * @returns the result of  operation and related info
            */
            [OperationContract]
            AuthResult ChangePassword(string userName, string pwd, string token);
    }
}
