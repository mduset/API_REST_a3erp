using System;
using System.Collections;
using System.Net.Http;
using System.Web.Http;
using API_REST_NAX.DTO;

namespace API_REST_NAX.Controllers
{
    /// <summary>
    /// Utilitats API REST per la gestió de Comptes amb A3ERP
    /// </summary>
    public class AccountController : BaseController
    {
        private readonly String MasterName = "Cuentas";
        /// <summary>
        /// Obtenir totes les comptes
        /// </summary>
        /// <returns>Llistat de comptes</returns>
        // GET api/account
        public HttpResponseMessage Get()
        {
            OpenLink();
            OpenMaster(MasterName);
            maestro.Primero();

            ArrayList accounts = new ArrayList();
            while (!maestro.EOF)
            {
                accounts.Add(PopulateAccount());
                maestro.Siguiente();
            }
            CloseMasterLink();

            return CreateOkResponse(accounts);
        }

        /// <summary>
        /// Obtenir un compte
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Compte</returns>
        // GET api/account/5
        public HttpResponseMessage Get(double id)
        {
            OpenLink();
            OpenMaster(MasterName);

            Account account = new Account();
            account.Id = id;

            if (maestro.Buscar(account.Id))
            {
                account = PopulateAccount();
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(account);
            }
            CloseMasterLink();

            return CreateOkResponse(account);
        }

        /// <summary>
        ///  Afegir un compte
        /// </summary>
        /// <param name="account">Compte</param>
        /// <returns></returns>
        // POST api/account
        public HttpResponseMessage Post([FromBody]Account account)
        {
            if (account == null)
            {
                return CreateBadRequest(account, "No ha indicat un compte a afegir");
            }
            OpenLink();
            OpenMaster(MasterName);

            if (account.Id < 1)
            {
                account.Id = int.Parse(maestro.NuevoCodigoNum());
            }
            if (maestro.Buscar(account.Id))
            {
                return CreateConflictRequest(account, "Vol afegir un compte amb un id que ja existeix");
            }

            try
            {
                maestro.Nuevo();
                PopulateMaster(account);
                maestro.Guarda(false);
            } catch (Exception e)
            {
                CloseMasterLink();
                return CreateInternalServerErrorRequest(account, e.Message);
            }
            CloseMasterLink();
            return CreateOkResponse(account);
        }

        /// <summary>
        ///  Modificar un compte
        /// </summary>
        /// <param name="id"> Id del compte a modificar</param>
        /// <param name="account">Compte a modificar</param>
        /// <returns></returns>
        // PUT api/account/5
        public HttpResponseMessage Put(double id, [FromBody]Account account)
        {
            OpenLink();
            OpenMaster(MasterName);

            if (maestro.Buscar(id))
            {
                try
                {
                    maestro.Edita();
                    PopulateMaster(account);
                    maestro.Guarda(true);
                }catch (Exception e)
                {
                    CloseMasterLink();
                    return CreateBadRequest(account, e.Message);
                }
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(account);
            }

            CloseMasterLink();
            return CreateOkResponse(account);
        }

        /// <summary>
        /// Esborrar un compte
        /// </summary>
        /// <param name="id">Identificador del compte</param>
        /// <returns></returns>
        // DELETE api/account/5
        public HttpResponseMessage Delete(double id)
        {
            OpenLink();

            Account account = new Account
            {
                Id = id
            };

            OpenMaster(MasterName);
            if (maestro.Buscar(account.Id))
            {
                maestro.Borrar();
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(account);
            }
            CloseMasterLink();
            return CreateOkResponse(account);
        }
    
        private Account PopulateAccount()
        {
            Account account = new Account
            {
                //Id = GetIntegerField("IDCUENTA"),
                Id = GetFloatField("IDCUENTA"),
                SupportCoin = GetStringField("ADMITEMONEDAS"),
                Account_ = GetStringField("CUENTA"),
                Description = GetStringField("DESCCUE"),
                Detail = GetStringField("DETALLE"),
                NBSA = GetStringField("NBSA"),
                NBSAP = GetStringField("NBSAP"),
                NBSN = GetStringField("NBSN"),
                NBSNP = GetStringField("NBSNP"),
                NBSP = GetStringField("NBSP"),
                NBSPP = GetStringField("NBSPP"),
                Level = GetIntegerField("NIVEL")
            };

            return account;
        }

        private void PopulateMaster(Account account)
        {
            //PopulateIntegerFieldIfExists("IDCUENTA", account.Id);
            PopulateFloatFieldIfExists("IDCUENTA", account.Id);
            PopulateStringFieldIfExists("ADMITEMONEDAS", account.SupportCoin);
            PopulateStringFieldIfExists("CUENTA", account.Account_);
            PopulateStringFieldIfExists("DESCCUE", account.Description);
            PopulateStringFieldIfExists("DETALLE", account.Detail);
            PopulateStringFieldIfExists("NBSA", account.NBSA);
            PopulateStringFieldIfExists("NBSAP", account.NBSAP);
            PopulateStringFieldIfExists("NBSN", account.NBSN);
            PopulateStringFieldIfExists("NBSNP", account.NBSNP);
            PopulateStringFieldIfExists("NBSP", account.NBSP);
            PopulateStringFieldIfExists("NBSPP", account.NBSPP);
            PopulateIntegerFieldIfExists("NIVEL", account.Level);
        }
    }
}
