using System;
using System.Collections;
using System.Net.Http;
using System.Web.Http;
using API_REST_NAX.DTO;

namespace API_REST_NAX.Controllers
{
    /// <summary>
    /// Utilitats API REST per la gestió de Bancs amb A3ERP
    /// </summary>
    public class BankController : BaseController
    {
        private readonly String MasterName = "Bancos";
        /// <summary>
        /// Obtenir tots els bancs
        /// </summary>
        /// <returns>Llistat de bancs</returns>
        // GET api/bank
        public HttpResponseMessage Get()
        {
            OpenLink();
            OpenMaster(MasterName);
            maestro.Primero();

            ArrayList bancs = new ArrayList();
            while (!maestro.EOF)
            {
                bancs.Add(PopulateBank());
                maestro.Siguiente();
            }
            CloseMasterLink();

            return CreateOkResponse(bancs);
        }

        /// <summary>
        /// Obtenir un banc
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Banc</returns>
        // GET api/banc/5
        public HttpResponseMessage Get(string id)
        {
            OpenLink();
            OpenMaster(MasterName);

            Bank bank = new Bank
            {
                Id = id
            };

            if (maestro.Buscar(bank.Id))
            {
                bank = PopulateBank();
            } else
            {
                CloseMasterLink();

                return CreateNotFoundResponse(bank);
            }
            CloseMasterLink();

            return CreateOkResponse(bank);
        }

        /// <summary>
        ///  Afegir un client
        /// </summary>
        /// <param name="bank"></param>
        // POST api/bank
        public HttpResponseMessage Post([FromBody]Bank bank)
        {
            if (bank == null)
            {
                return CreateBadRequest(bank, "No ha indicat un banc a afegir");
            }
            OpenLink();
            OpenMaster(MasterName);

            if (bank.Id is null)
            {
                bank.Id = maestro.NuevoCodigoNum();
            }
            if (maestro.Buscar(bank.Id))
            {
                return CreateConflictRequest(bank, "Vol afegir un banc amb un id que ja existeix");
            }

            try
            {
                maestro.Nuevo();
                PopulateMaster(bank, bank.Id);
                maestro.Guarda(false);
            } catch (Exception e)
            {
                CloseMasterLink();
                return CreateInternalServerErrorRequest(bank, e.Message);
            }
            CloseMasterLink();
            return CreateOkResponse(bank);
        }

        /// <summary>
        /// Modificar un banc
        /// </summary>
        /// <param name="id">Identificador del banc</param>
        /// <param name="bank">Banc</param>
        /// <returns></returns>
        // PUT api/client/5
        public HttpResponseMessage Put(string id, [FromBody]Bank bank)
        {
            OpenLink();
            OpenMaster(MasterName);

            if (maestro.Buscar(id))
            {
                try
                {
                    maestro.Edita();
                    PopulateMaster(bank, id);
                    maestro.Guarda(true);
                }catch (Exception e)
                {
                    CloseMasterLink();
                    return CreateBadRequest(bank, e.Message);
                }
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(bank);
            }

            CloseMasterLink();
            return CreateOkResponse(bank);
        }

        /// <summary>
        /// Esborrar un banc
        /// </summary>
        /// <param name="id">Identificador del banc</param>
        /// <returns></returns>
        // DELETE api/banc/5
        public HttpResponseMessage Delete(string id)
        {
            OpenLink();

            Bank bank = new Bank();
            bank.Id = id;

            OpenMaster(MasterName);
            if (maestro.Buscar(bank.Id))
            {
                maestro.Borrar();
            } else
            {
                CloseMasterLink();
                return CreateNotFoundResponse(bank);
            }
            CloseMasterLink();
            return CreateOkResponse(bank);
        }
    
        private Bank PopulateBank()
        {
            Bank bank = new Bank
            {
                Id = GetStringField("CODBAN"),
                Ageban = GetStringField("AGEBAN"),
                Agency = GetStringField("AGENCIA"),
                BIC = GetStringField("BIC"),
                Country = GetStringField("CODPAIS"),
                Province = GetStringField("CODPRO"),
                DebtAccount = GetStringField("CTADEUDA"),
                Account = GetStringField("CUENTA"),
                Digit = GetStringField("DIGCONT"),
                Direction = GetStringField("DIRBAN"),
                PostalCode = GetStringField("DTOBAN"),
                Email = GetStringField("E_MAIL"),
                Fax = GetStringField("FAXBAN"),
                IBAN = GetStringField("IBAN"),
                Name = GetStringField("NOMBAN"),
                AccountNumber = GetStringField("NUMCUE"),
                Observations = GetStringField("OBSBAN"),
                Web = GetStringField("PAGINAWEB"),
                Town = GetStringField("POBBAN"),
                Telephone = GetStringField("TELBAN"),
                Telephone2 = GetStringField("TEL2BAN"),
                ExternalBIC = GetStringField("BICEXT"),
                ExternalAccount = GetStringField("CUENTAEXT"),
                ExternalIBAN = GetStringField("IBANEXT"),
                SEPAArea = GetStringField("ZONASEPA")
            };

            return bank;
        }

        private void PopulateMaster(Bank bank, String id)
        {
            PopulateStringFieldIfExists("CODBAN", id);

            PopulateStringFieldIfExists("AGEBAN", bank.Ageban);
            PopulateStringFieldIfExists("AGENCIA", bank.Agency);
            PopulateStringFieldIfExists("BIC", bank.BIC);
            PopulateStringFieldIfExists("CODPAIS", bank.Country);
            PopulateStringFieldIfExists("CODPRO", bank.Province);
            PopulateStringFieldIfExists("CTADEUDA", bank.DebtAccount);

            PopulateStringFieldIfExists("CUENTA", bank.Account);
            PopulateStringFieldIfExists("DIGCONT", bank.Digit);
            PopulateStringFieldIfExists("DIRBAN", bank.Direction);

            PopulateStringFieldIfExists("DTOBAN", bank.PostalCode);
            PopulateStringFieldIfExists("E_MAIL", bank.Email);
            PopulateStringFieldIfExists("FAXBAN", bank.Fax);
            PopulateStringFieldIfExists("IBAN", bank.IBAN);


            PopulateStringFieldIfExists("NOMBAN", bank.Name);
            PopulateStringFieldIfExists("NUMCUE", bank.AccountNumber);
            PopulateStringFieldIfExists("OBSBAN", bank.Observations);
            PopulateStringFieldIfExists("PAGINAWEB", bank.Web);


            PopulateStringFieldIfExists("POBBAN", bank.Town);
            PopulateStringFieldIfExists("TELBAN", bank.Telephone);
            PopulateStringFieldIfExists("TEL2BAN", bank.Telephone2);
            PopulateStringFieldIfExists("BICEXT", bank.ExternalBIC);
            PopulateStringFieldIfExists("CUENTAEXT", bank.ExternalAccount);

            PopulateStringFieldIfExists("IBANEXT", bank.ExternalIBAN);
            PopulateStringFieldIfExists("ZONASEPA", bank.SEPAArea);
            PopulateStringFieldIfExists("E_MAIL_DOCS", bank.Email);
            PopulateStringFieldIfExists("CODPAIS", bank.Country);
            PopulateStringFieldIfExists("CUENTAEXT", bank.ExternalAccount);
        }
    }
}
