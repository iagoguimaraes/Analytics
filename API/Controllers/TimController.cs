﻿using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/tim")]
    public class TimController : ApiController
    {
        [Route("cubo")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage Cubo(FormDataCollection form)
        {
            try
            {
                DataSet resultado = new bTim().Cubo();

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/filtros")]
        [HttpGet]
        [Autenticar]
        [Autorizar]
        public HttpResponseMessage DashboardFiltros()
        {
            try
            {
                DataSet resultado = new bTim().DashboardFiltros();

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/horahora")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHora(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string campanhas = form["campanhas"];

                DataSet resultado = new bTim().DashboardHoraHora(dtini,dtfim, campanhas);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/btc")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardBTC(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string campanhas = form["campanhas"];

                DataSet resultado = new bTim().DashboardBTC(dtini, dtfim, campanhas);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Route("dashboard/producao")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardProducao(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string filas = form["filas"];

                DataSet resultado = new bTim().DashboardProducao(dtini, dtfim, filas);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


    }
}
