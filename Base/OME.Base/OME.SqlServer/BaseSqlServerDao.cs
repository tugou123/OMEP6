using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;

namespace OME.SqlServer
{

    public abstract class BaseSqlServerDao: DisposableObject
    {
        private readonly string _connectionString;
        private IDbConnection _dbConnection;

        private IDbTransaction _dbTransaction;


        public virtual IDbConnection Connection
        {
            get
            {
                return _dbConnection;
            }
            set { _dbConnection = value; }
        }

        public BaseSqlServerDao() { }

        public BaseSqlServerDao(string connectString)
        {
            _connectionString = connectString;
            _dbConnection = new SqlConnection(_connectionString);
            if (_dbConnection.State == ConnectionState.Broken || _dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
        }

        public BaseSqlServerDao(SqlConnection sqlConnection)
        {
            _dbConnection = sqlConnection;
            if (_dbConnection.State == ConnectionState.Broken || _dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
        }


        public virtual void TransactionBegin() => _dbTransaction = _dbConnection.BeginTransaction();


        public virtual void Rollback() =>  _dbTransaction.Rollback();


        public virtual void TransactionCommite() => _dbTransaction.Commit();


        public void Invoke<TReturn>(Action action)
        {
            try
            {
                action();
            }
            catch ( TimeoutException ex)
            {

                throw ex;

            }
            catch (SqlException ex)
            {

                throw ex;

            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {

            }
        }


       public async Task InvokeAsync(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (TimeoutException ex)
            {

                throw ex;

            }
            catch (SqlException ex)
            {

                throw ex;

            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {

            }
        }


        public TReturn Invoke<TReturn>(Func<TReturn> func)
        {
            try
            {
                return func();
            }
            catch (TimeoutException ex)
            {

                throw ex;

            }
            catch (SqlException ex)
            {

                throw ex;

            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {

            }
        }


        public async Task< TReturn> InvokeAsync<TReturn>(Func<Task<TReturn>> func)
        {
            try
            {
             return   await func();
            }
            catch (TimeoutException ex)
            {

                throw ex;

            }
            catch (SqlException ex)
            {

                throw ex;

            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {

            }
        }


       protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }

            if (_dbTransaction != null)
            {
                _dbTransaction.Dispose();
            }

            if (_dbConnection != null)
            {
                _dbConnection.Dispose();
            }
        }
    }



    public abstract class DisposableObject : IDisposable
    {
      

        public void Dispose()
        {
           
        }

        protected abstract void Dispose(bool disposing);
    }
}

