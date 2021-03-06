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
    [RoutePrefix("api/vivo")]
    public class VivoController : ApiController
    {

        [Route("dashboard/horahora")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardHoraHora(FormDataCollection form)
        {
            try
            {
                string data = form["data"];
                string segmentacoes = form["segmentacoes"];
                string campanhas = form["campanhas"];
                

                DataSet resultado = new bVivo().DashboardHoraHora(data, segmentacoes, campanhas);

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
                DataSet resultado = new bVivo().DashboardFiltros();

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
                string segmentacoes = form["segmentacoes"];
                string campanhas = form["campanhas"];


                DataSet resultado = new bVivo().DashboardProducao(dtini, dtfim, segmentacoes, campanhas);

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
                string segmentacoes = form["segmentacoes"];
                string campanhas = form["campanhas"];


                DataSet resultado = new bVivo().DashboardBTC(dtini, dtfim, segmentacoes, campanhas);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/lote")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardLote(FormDataCollection form)
        {
            try
            {
                DataSet resultado = new bVivo().DashboardLote();

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/pagamento")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardPagamento(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string segmentacoes = form["segmentacoes"];

                DataSet resultado = new bVivo().DashboardPagamento(dtini, dtfim, segmentacoes);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("dashboard/carteira")]
        [HttpPost]
        [Autenticar]
        [Autorizar]
        [Gravar]
        public HttpResponseMessage DashboardCarteira(FormDataCollection form)
        {
            try
            {
                string dtini = form["dtini"];
                string dtfim = form["dtfim"];
                string segmentacoes = form["segmentacoes"];

                DataSet resultado = new bVivo().DashboardCarteira(dtini, dtfim, segmentacoes);

                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
