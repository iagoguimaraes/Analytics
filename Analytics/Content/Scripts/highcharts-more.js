﻿/*
 Highcharts JS v6.1.1 (2018-06-27)

 (c) 2009-2016 Torstein Honsi

 License: www.highcharts.com/license
*/
(function (w) { "object" === typeof module && module.exports ? module.exports = w : w(Highcharts) })(function (w) {
    (function (a) {
        function p(a, b) { this.init(a, b) } var v = a.CenteredSeriesMixin, u = a.each, q = a.extend, r = a.merge, g = a.splat; q(p.prototype, {
            coll: "pane", init: function (a, b) { this.chart = b; this.background = []; b.pane.push(this); this.setOptions(a) }, setOptions: function (a) { this.options = r(this.defaultOptions, this.chart.angular ? { background: {} } : void 0, a) }, render: function () {
                var a = this.options, b = this.options.background, c = this.chart.renderer;
                this.group || (this.group = c.g("pane-group").attr({ zIndex: a.zIndex || 0 }).add()); this.updateCenter(); if (b) for (b = g(b), a = Math.max(b.length, this.background.length || 0), c = 0; c < a; c++) b[c] && this.axis ? this.renderBackground(r(this.defaultBackgroundOptions, b[c]), c) : this.background[c] && (this.background[c] = this.background[c].destroy(), this.background.splice(c, 1))
            }, renderBackground: function (a, b) {
                var c = "animate"; this.background[b] || (this.background[b] = this.chart.renderer.path().add(this.group), c = "attr"); this.background[b][c]({
                    d: this.axis.getPlotBandPath(a.from,
                    a.to, a)
                }).attr({ fill: a.backgroundColor, stroke: a.borderColor, "stroke-width": a.borderWidth, "class": "highcharts-pane " + (a.className || "") })
            }, defaultOptions: { center: ["50%", "50%"], size: "85%", startAngle: 0 }, defaultBackgroundOptions: { shape: "circle", borderWidth: 1, borderColor: "#cccccc", backgroundColor: { linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 }, stops: [[0, "#ffffff"], [1, "#e6e6e6"]] }, from: -Number.MAX_VALUE, innerRadius: 0, to: Number.MAX_VALUE, outerRadius: "105%" }, updateCenter: function (a) {
                this.center = (a || this.axis || {}).center =
                v.getCenter.call(this)
            }, update: function (a, b) { r(!0, this.options, a); this.setOptions(this.options); this.render(); u(this.chart.axes, function (c) { c.pane === this && (c.pane = null, c.update({}, b)) }, this) }
        }); a.Pane = p
    })(w); (function (a) {
        var p = a.addEvent, v = a.Axis, u = a.each, q = a.extend, r = a.map, g = a.merge, m = a.noop, b = a.pick, c = a.pInt, d = a.Tick, k = a.wrap, e = a.correctFloat, f, h, t = v.prototype, l = d.prototype; a.radialAxisExtended || (a.radialAxisExtended = !0, f = {
            getOffset: m, redraw: function () { this.isDirty = !1 }, render: function () {
                this.isDirty =
                !1
            }, setScale: m, setCategories: m, setTitle: m
        }, h = {
            defaultRadialGaugeOptions: { labels: { align: "center", x: 0, y: null }, minorGridLineWidth: 0, minorTickInterval: "auto", minorTickLength: 10, minorTickPosition: "inside", minorTickWidth: 1, tickLength: 10, tickPosition: "inside", tickWidth: 2, title: { rotation: 0 }, zIndex: 2 }, defaultRadialXOptions: { gridLineWidth: 1, labels: { align: null, distance: 15, x: 0, y: null, style: { textOverflow: "none" } }, maxPadding: 0, minPadding: 0, showLastLabel: !1, tickLength: 0 }, defaultRadialYOptions: {
                gridLineInterpolation: "circle",
                labels: { align: "right", x: -3, y: -2 }, showLastLabel: !1, title: { x: 4, text: null, rotation: 90 }
            }, setOptions: function (b) { b = this.options = g(this.defaultOptions, this.defaultRadialOptions, b); b.plotBands || (b.plotBands = []); a.fireEvent(this, "afterSetOptions") }, getOffset: function () { t.getOffset.call(this); this.chart.axisOffset[this.side] = 0 }, getLinePath: function (c, d) {
                c = this.center; var a = this.chart, n = b(d, c[2] / 2 - this.offset); this.isCircular || void 0 !== d ? (d = this.chart.renderer.symbols.arc(this.left + c[0], this.top + c[1], n, n, {
                    start: this.startAngleRad,
                    end: this.endAngleRad, open: !0, innerR: 0
                }), d.xBounds = [this.left + c[0]], d.yBounds = [this.top + c[1] - n]) : (d = this.postTranslate(this.angleRad, n), d = ["M", c[0] + a.plotLeft, c[1] + a.plotTop, "L", d.x, d.y]); return d
            }, setAxisTranslation: function () { t.setAxisTranslation.call(this); this.center && (this.transA = this.isCircular ? (this.endAngleRad - this.startAngleRad) / (this.max - this.min || 1) : this.center[2] / 2 / (this.max - this.min || 1), this.minPixelPadding = this.isXAxis ? this.transA * this.minPointOffset : 0) }, beforeSetTickPositions: function () {
                if (this.autoConnect =
                this.isCircular && void 0 === b(this.userMax, this.options.max) && e(this.endAngleRad - this.startAngleRad) === e(2 * Math.PI)) this.max += this.categories && 1 || this.pointRange || this.closestPointRange || 0
            }, setAxisSize: function () { t.setAxisSize.call(this); this.isRadial && (this.pane.updateCenter(this), this.isCircular && (this.sector = this.endAngleRad - this.startAngleRad), this.len = this.width = this.height = this.center[2] * b(this.sector, 1) / 2) }, getPosition: function (c, d) {
                return this.postTranslate(this.isCircular ? this.translate(c) :
                this.angleRad, b(this.isCircular ? d : this.translate(c), this.center[2] / 2) - this.offset)
            }, postTranslate: function (b, c) { var d = this.chart, a = this.center; b = this.startAngleRad + b; return { x: d.plotLeft + a[0] + Math.cos(b) * c, y: d.plotTop + a[1] + Math.sin(b) * c } }, getPlotBandPath: function (d, a, e) {
                var f = this.center, n = this.startAngleRad, k = f[2] / 2, h = [b(e.outerRadius, "100%"), e.innerRadius, b(e.thickness, 10)], l = Math.min(this.offset, 0), x = /%$/, t, B = this.isCircular; "polygon" === this.options.gridLineInterpolation ? f = this.getPlotLinePath(d).concat(this.getPlotLinePath(a,
                !0)) : (d = Math.max(d, this.min), a = Math.min(a, this.max), B || (h[0] = this.translate(d), h[1] = this.translate(a)), h = r(h, function (b) { x.test(b) && (b = c(b, 10) * k / 100); return b }), "circle" !== e.shape && B ? (d = n + this.translate(d), a = n + this.translate(a)) : (d = -Math.PI / 2, a = 1.5 * Math.PI, t = !0), h[0] -= l, h[2] -= l, f = this.chart.renderer.symbols.arc(this.left + f[0], this.top + f[1], h[0], h[0], { start: Math.min(d, a), end: Math.max(d, a), innerR: b(h[1], h[0] - h[2]), open: t })); return f
            }, getPlotLinePath: function (b, c) {
                var d = this, a = d.center, f = d.chart, e = d.getPosition(b),
                h, k, n; d.isCircular ? n = ["M", a[0] + f.plotLeft, a[1] + f.plotTop, "L", e.x, e.y] : "circle" === d.options.gridLineInterpolation ? (b = d.translate(b)) && (n = d.getLinePath(0, b)) : (u(f.xAxis, function (b) { b.pane === d.pane && (h = b) }), n = [], b = d.translate(b), a = h.tickPositions, h.autoConnect && (a = a.concat([a[0]])), c && (a = [].concat(a).reverse()), u(a, function (c, d) { k = h.getPosition(c, b); n.push(d ? "L" : "M", k.x, k.y) })); return n
            }, getTitlePosition: function () {
                var b = this.center, c = this.chart, d = this.options.title; return {
                    x: c.plotLeft + b[0] + (d.x || 0),
                    y: c.plotTop + b[1] - { high: .5, middle: .25, low: 0 }[d.align] * b[2] + (d.y || 0)
                }
            }
        }, p(v, "init", function (b) {
            var c = this.chart, d = c.angular, a = c.polar, e = this.isXAxis, k = d && e, n, l = c.options; b = b.userOptions.pane || 0; b = this.pane = c.pane && c.pane[b]; if (d) { if (q(this, k ? f : h), n = !e) this.defaultRadialOptions = this.defaultRadialGaugeOptions } else a && (q(this, h), this.defaultRadialOptions = (n = e) ? this.defaultRadialXOptions : g(this.defaultYAxisOptions, this.defaultRadialYOptions)); d || a ? (this.isRadial = !0, c.inverted = !1, l.chart.zoomType = null) :
            this.isRadial = !1; b && n && (b.axis = this); this.isCircular = n
        }), p(v, "afterInit", function () { var c = this.chart, d = this.options, a = this.pane, e = a && a.options; c.angular && this.isXAxis || !a || !c.angular && !c.polar || (this.angleRad = (d.angle || 0) * Math.PI / 180, this.startAngleRad = (e.startAngle - 90) * Math.PI / 180, this.endAngleRad = (b(e.endAngle, e.startAngle + 360) - 90) * Math.PI / 180, this.offset = d.offset || 0) }), k(t, "autoLabelAlign", function (b) { if (!this.isRadial) return b.apply(this, [].slice.call(arguments, 1)) }), p(d, "afterGetPosition", function (b) {
            this.axis.getPosition &&
            q(b.pos, this.axis.getPosition(this.pos))
        }), p(d, "afterGetLabelPosition", function (c) {
            var d = this.axis, a = this.label, e = d.options.labels, f = e.y, h, k = 20, l = e.align, n = (d.translate(this.pos) + d.startAngleRad + Math.PI / 2) / Math.PI * 180 % 360; d.isRadial && (h = d.getPosition(this.pos, d.center[2] / 2 + b(e.distance, -25)), "auto" === e.rotation ? a.attr({ rotation: n }) : null === f && (f = d.chart.renderer.fontMetrics(a.styles && a.styles.fontSize).b - a.getBBox().height / 2), null === l && (d.isCircular ? (this.label.getBBox().width > d.len * d.tickInterval /
            (d.max - d.min) && (k = 0), l = n > k && n < 180 - k ? "left" : n > 180 + k && n < 360 - k ? "right" : "center") : l = "center", a.attr({ align: l })), c.pos.x = h.x + e.x, c.pos.y = h.y + f)
        }), k(l, "getMarkPath", function (b, c, d, a, e, f, h) { var k = this.axis; k.isRadial ? (b = k.getPosition(this.pos, k.center[2] / 2 + a), c = ["M", c, d, "L", b.x, b.y]) : c = b.call(this, c, d, a, e, f, h); return c }))
    })(w); (function (a) {
        var p = a.each, v = a.pick, u = a.defined, q = a.seriesType, r = a.seriesTypes, g = a.Series.prototype, m = a.Point.prototype; q("arearange", "area", {
            lineWidth: 1, threshold: null, tooltip: { pointFormat: '\x3cspan style\x3d"color:{series.color}"\x3e\u25cf\x3c/span\x3e {series.name}: \x3cb\x3e{point.low}\x3c/b\x3e - \x3cb\x3e{point.high}\x3c/b\x3e\x3cbr/\x3e' },
            trackByArea: !0, dataLabels: { align: null, verticalAlign: null, xLow: 0, xHigh: 0, yLow: 0, yHigh: 0 }
        }, {
            pointArrayMap: ["low", "high"], dataLabelCollections: ["dataLabel", "dataLabelUpper"], toYData: function (b) { return [b.low, b.high] }, pointValKey: "low", deferTranslatePolar: !0, highToXY: function (b) { var c = this.chart, d = this.xAxis.postTranslate(b.rectPlotX, this.yAxis.len - b.plotHigh); b.plotHighX = d.x - c.plotLeft; b.plotHigh = d.y - c.plotTop; b.plotLowX = b.plotX }, translate: function () {
                var b = this, c = b.yAxis, d = !!b.modifyValue; r.area.prototype.translate.apply(b);
                p(b.points, function (a) { var e = a.low, f = a.high, h = a.plotY; null === f || null === e ? (a.isNull = !0, a.plotY = null) : (a.plotLow = h, a.plotHigh = c.translate(d ? b.modifyValue(f, a) : f, 0, 1, 0, 1), d && (a.yBottom = a.plotHigh)) }); this.chart.polar && p(this.points, function (c) { b.highToXY(c); c.tooltipPos = [(c.plotHighX + c.plotLowX) / 2, (c.plotHigh + c.plotLow) / 2] })
            }, getGraphPath: function (b) {
                var c = [], d = [], a, e = r.area.prototype.getGraphPath, f, h, t; t = this.options; var l = this.chart.polar && !1 !== t.connectEnds, n = t.connectNulls, x = t.step; b = b || this.points;
                for (a = b.length; a--;) f = b[a], f.isNull || l || n || b[a + 1] && !b[a + 1].isNull || d.push({ plotX: f.plotX, plotY: f.plotY, doCurve: !1 }), h = { polarPlotY: f.polarPlotY, rectPlotX: f.rectPlotX, yBottom: f.yBottom, plotX: v(f.plotHighX, f.plotX), plotY: f.plotHigh, isNull: f.isNull }, d.push(h), c.push(h), f.isNull || l || n || b[a - 1] && !b[a - 1].isNull || d.push({ plotX: f.plotX, plotY: f.plotY, doCurve: !1 }); b = e.call(this, b); x && (!0 === x && (x = "left"), t.step = { left: "right", center: "center", right: "left" }[x]); c = e.call(this, c); d = e.call(this, d); t.step = x; t = [].concat(b,
                c); this.chart.polar || "M" !== d[0] || (d[0] = "L"); this.graphPath = t; this.areaPath = b.concat(d); t.isArea = !0; t.xMap = b.xMap; this.areaPath.xMap = b.xMap; return t
            }, drawDataLabels: function () {
                var b = this.data, c = b.length, d, a = [], e = this.options.dataLabels, f = e.align, h = e.verticalAlign, t = e.inside, l, n, x = this.chart.inverted; if (e.enabled || this._hasPointLabels) {
                    for (d = c; d--;) if (l = b[d]) n = t ? l.plotHigh < l.plotLow : l.plotHigh > l.plotLow, l.y = l.high, l._plotY = l.plotY, l.plotY = l.plotHigh, a[d] = l.dataLabel, l.dataLabel = l.dataLabelUpper, l.below =
                    n, x ? f || (e.align = n ? "right" : "left") : h || (e.verticalAlign = n ? "top" : "bottom"), e.x = e.xHigh, e.y = e.yHigh; g.drawDataLabels && g.drawDataLabels.apply(this, arguments); for (d = c; d--;) if (l = b[d]) n = t ? l.plotHigh < l.plotLow : l.plotHigh > l.plotLow, l.dataLabelUpper = l.dataLabel, l.dataLabel = a[d], l.y = l.low, l.plotY = l._plotY, l.below = !n, x ? f || (e.align = n ? "left" : "right") : h || (e.verticalAlign = n ? "bottom" : "top"), e.x = e.xLow, e.y = e.yLow; g.drawDataLabels && g.drawDataLabels.apply(this, arguments)
                } e.align = f; e.verticalAlign = h
            }, alignDataLabel: function () {
                r.column.prototype.alignDataLabel.apply(this,
                arguments)
            }, drawPoints: function () {
                var b = this.points.length, c, d; g.drawPoints.apply(this, arguments); for (d = 0; d < b;) c = this.points[d], c.origProps = { plotY: c.plotY, plotX: c.plotX, isInside: c.isInside, negative: c.negative, zone: c.zone, y: c.y }, c.lowerGraphic = c.graphic, c.graphic = c.upperGraphic, c.plotY = c.plotHigh, u(c.plotHighX) && (c.plotX = c.plotHighX), c.y = c.high, c.negative = c.high < (this.options.threshold || 0), c.zone = this.zones.length && c.getZone(), this.chart.polar || (c.isInside = c.isTopInside = void 0 !== c.plotY && 0 <= c.plotY &&
                c.plotY <= this.yAxis.len && 0 <= c.plotX && c.plotX <= this.xAxis.len), d++; g.drawPoints.apply(this, arguments); for (d = 0; d < b;) c = this.points[d], c.upperGraphic = c.graphic, c.graphic = c.lowerGraphic, a.extend(c, c.origProps), delete c.origProps, d++
            }, setStackedPoints: a.noop
        }, {
            setState: function () {
                var b = this.state, c = this.series, d = c.chart.polar; u(this.plotHigh) || (this.plotHigh = c.yAxis.toPixels(this.high, !0)); u(this.plotLow) || (this.plotLow = this.plotY = c.yAxis.toPixels(this.low, !0)); c.stateMarkerGraphic && (c.lowerStateMarkerGraphic =
                c.stateMarkerGraphic, c.stateMarkerGraphic = c.upperStateMarkerGraphic); this.graphic = this.upperGraphic; this.plotY = this.plotHigh; d && (this.plotX = this.plotHighX); m.setState.apply(this, arguments); this.state = b; this.plotY = this.plotLow; this.graphic = this.lowerGraphic; d && (this.plotX = this.plotLowX); c.stateMarkerGraphic && (c.upperStateMarkerGraphic = c.stateMarkerGraphic, c.stateMarkerGraphic = c.lowerStateMarkerGraphic, c.lowerStateMarkerGraphic = void 0); m.setState.apply(this, arguments)
            }, haloPath: function () {
                var b = this.series.chart.polar,
                c = []; this.plotY = this.plotLow; b && (this.plotX = this.plotLowX); this.isInside && (c = m.haloPath.apply(this, arguments)); this.plotY = this.plotHigh; b && (this.plotX = this.plotHighX); this.isTopInside && (c = c.concat(m.haloPath.apply(this, arguments))); return c
            }, destroyElements: function () { p(["lowerGraphic", "upperGraphic"], function (b) { this[b] && (this[b] = this[b].destroy()) }, this); this.graphic = null; return m.destroyElements.apply(this, arguments) }
        })
    })(w); (function (a) {
        var p = a.seriesType; p("areasplinerange", "arearange", null,
        { getPointSpline: a.seriesTypes.spline.prototype.getPointSpline })
    })(w); (function (a) {
        var p = a.defaultPlotOptions, v = a.each, u = a.merge, q = a.noop, r = a.pick, g = a.seriesType, m = a.seriesTypes.column.prototype; g("columnrange", "arearange", u(p.column, p.arearange, { pointRange: null, marker: null, states: { hover: { halo: !1 } } }), {
            translate: function () {
                var b = this, c = b.yAxis, d = b.xAxis, a = d.startAngleRad, e, f = b.chart, h = b.xAxis.isRadial, t = Math.max(f.chartWidth, f.chartHeight) + 999, l; m.translate.apply(b); v(b.points, function (n) {
                    var k = n.shapeArgs,
                    m = b.options.minPointLength, y, g; n.plotHigh = l = Math.min(Math.max(-t, c.translate(n.high, 0, 1, 0, 1)), t); n.plotLow = Math.min(Math.max(-t, n.plotY), t); g = l; y = r(n.rectPlotY, n.plotY) - l; Math.abs(y) < m ? (m -= y, y += m, g -= m / 2) : 0 > y && (y *= -1, g -= y); h ? (e = n.barX + a, n.shapeType = "path", n.shapeArgs = { d: b.polarArc(g + y, g, e, e + n.pointWidth) }) : (k.height = y, k.y = g, n.tooltipPos = f.inverted ? [c.len + c.pos - f.plotLeft - g - y / 2, d.len + d.pos - f.plotTop - k.x - k.width / 2, y] : [d.left - f.plotLeft + k.x + k.width / 2, c.pos - f.plotTop + g + y / 2, y])
                })
            }, directTouch: !0, trackerGroups: ["group",
            "dataLabelsGroup"], drawGraph: q, getSymbol: q, crispCol: m.crispCol, drawPoints: m.drawPoints, drawTracker: m.drawTracker, getColumnMetrics: m.getColumnMetrics, pointAttribs: m.pointAttribs, animate: function () { return m.animate.apply(this, arguments) }, polarArc: function () { return m.polarArc.apply(this, arguments) }, translate3dPoints: function () { return m.translate3dPoints.apply(this, arguments) }, translate3dShapes: function () { return m.translate3dShapes.apply(this, arguments) }
        }, { setState: m.pointClass.prototype.setState })
    })(w);
    (function (a) {
        var p = a.each, v = a.isNumber, u = a.merge, q = a.pick, r = a.pInt, g = a.Series, m = a.seriesType, b = a.TrackerMixin; m("gauge", "line", { dataLabels: { enabled: !0, defer: !1, y: 15, borderRadius: 3, crop: !1, verticalAlign: "top", zIndex: 2, borderWidth: 1, borderColor: "#cccccc" }, dial: {}, pivot: {}, tooltip: { headerFormat: "" }, showInLegend: !1 }, {
            angular: !0, directTouch: !0, drawGraph: a.noop, fixedBox: !0, forceDL: !0, noSharedTooltip: !0, trackerGroups: ["group", "dataLabelsGroup"], translate: function () {
                var b = this.yAxis, d = this.options, a = b.center;
                this.generatePoints(); p(this.points, function (c) {
                    var e = u(d.dial, c.dial), h = r(q(e.radius, 80)) * a[2] / 200, k = r(q(e.baseLength, 70)) * h / 100, l = r(q(e.rearLength, 10)) * h / 100, n = e.baseWidth || 3, x = e.topWidth || 1, g = d.overshoot, m = b.startAngleRad + b.translate(c.y, null, null, null, !0); v(g) ? (g = g / 180 * Math.PI, m = Math.max(b.startAngleRad - g, Math.min(b.endAngleRad + g, m))) : !1 === d.wrap && (m = Math.max(b.startAngleRad, Math.min(b.endAngleRad, m))); m = 180 * m / Math.PI; c.shapeType = "path"; c.shapeArgs = {
                        d: e.path || ["M", -l, -n / 2, "L", k, -n / 2, h, -x / 2, h,
                        x / 2, k, n / 2, -l, n / 2, "z"], translateX: a[0], translateY: a[1], rotation: m
                    }; c.plotX = a[0]; c.plotY = a[1]
                })
            }, drawPoints: function () {
                var b = this, a = b.yAxis.center, k = b.pivot, e = b.options, f = e.pivot, h = b.chart.renderer; p(b.points, function (c) {
                    var a = c.graphic, d = c.shapeArgs, f = d.d, k = u(e.dial, c.dial); a ? (a.animate(d), d.d = f) : (c.graphic = h[c.shapeType](d).attr({ rotation: d.rotation, zIndex: 1 }).addClass("highcharts-dial").add(b.group), c.graphic.attr({
                        stroke: k.borderColor || "none", "stroke-width": k.borderWidth || 0, fill: k.backgroundColor ||
                        "#000000"
                    }))
                }); k ? k.animate({ translateX: a[0], translateY: a[1] }) : (b.pivot = h.circle(0, 0, q(f.radius, 5)).attr({ zIndex: 2 }).addClass("highcharts-pivot").translate(a[0], a[1]).add(b.group), b.pivot.attr({ "stroke-width": f.borderWidth || 0, stroke: f.borderColor || "#cccccc", fill: f.backgroundColor || "#000000" }))
            }, animate: function (b) {
                var c = this; b || (p(c.points, function (b) { var a = b.graphic; a && (a.attr({ rotation: 180 * c.yAxis.startAngleRad / Math.PI }), a.animate({ rotation: b.shapeArgs.rotation }, c.options.animation)) }), c.animate =
                null)
            }, render: function () { this.group = this.plotGroup("group", "series", this.visible ? "visible" : "hidden", this.options.zIndex, this.chart.seriesGroup); g.prototype.render.call(this); this.group.clip(this.chart.clipRect) }, setData: function (b, a) { g.prototype.setData.call(this, b, !1); this.processData(); this.generatePoints(); q(a, !0) && this.chart.redraw() }, drawTracker: b && b.drawTrackerPoint
        }, { setState: function (b) { this.state = b } })
    })(w); (function (a) {
        var p = a.each, v = a.noop, u = a.pick, q = a.seriesType, r = a.seriesTypes; q("boxplot",
        "column", { threshold: null, tooltip: { pointFormat: '\x3cspan style\x3d"color:{point.color}"\x3e\u25cf\x3c/span\x3e \x3cb\x3e {series.name}\x3c/b\x3e\x3cbr/\x3eMaximum: {point.high}\x3cbr/\x3eUpper quartile: {point.q3}\x3cbr/\x3eMedian: {point.median}\x3cbr/\x3eLower quartile: {point.q1}\x3cbr/\x3eMinimum: {point.low}\x3cbr/\x3e' }, whiskerLength: "50%", fillColor: "#ffffff", lineWidth: 1, medianWidth: 2, whiskerWidth: 2 }, {
            pointArrayMap: ["low", "q1", "median", "q3", "high"], toYData: function (a) {
                return [a.low, a.q1, a.median,
                a.q3, a.high]
            }, pointValKey: "high", pointAttribs: function () { return {} }, drawDataLabels: v, translate: function () { var a = this.yAxis, m = this.pointArrayMap; r.column.prototype.translate.apply(this); p(this.points, function (b) { p(m, function (c) { null !== b[c] && (b[c + "Plot"] = a.translate(b[c], 0, 1, 0, 1)) }) }) }, drawPoints: function () {
                var a = this, m = a.options, b = a.chart.renderer, c, d, k, e, f, h, t = 0, l, n, x, r, q = !1 !== a.doQuartiles, v, z = a.options.whiskerLength; p(a.points, function (g) {
                    var p = g.graphic, y = p ? "animate" : "attr", B = g.shapeArgs, w = {}, D =
                    {}, I = {}, J = {}, C = g.color || a.color; void 0 !== g.plotY && (l = B.width, n = Math.floor(B.x), x = n + l, r = Math.round(l / 2), c = Math.floor(q ? g.q1Plot : g.lowPlot), d = Math.floor(q ? g.q3Plot : g.lowPlot), k = Math.floor(g.highPlot), e = Math.floor(g.lowPlot), p || (g.graphic = p = b.g("point").add(a.group), g.stem = b.path().addClass("highcharts-boxplot-stem").add(p), z && (g.whiskers = b.path().addClass("highcharts-boxplot-whisker").add(p)), q && (g.box = b.path(void 0).addClass("highcharts-boxplot-box").add(p)), g.medianShape = b.path(void 0).addClass("highcharts-boxplot-median").add(p)),
                    D.stroke = g.stemColor || m.stemColor || C, D["stroke-width"] = u(g.stemWidth, m.stemWidth, m.lineWidth), D.dashstyle = g.stemDashStyle || m.stemDashStyle, g.stem.attr(D), z && (I.stroke = g.whiskerColor || m.whiskerColor || C, I["stroke-width"] = u(g.whiskerWidth, m.whiskerWidth, m.lineWidth), g.whiskers.attr(I)), q && (w.fill = g.fillColor || m.fillColor || C, w.stroke = m.lineColor || C, w["stroke-width"] = m.lineWidth || 0, g.box.attr(w)), J.stroke = g.medianColor || m.medianColor || C, J["stroke-width"] = u(g.medianWidth, m.medianWidth, m.lineWidth), g.medianShape.attr(J),
                    h = g.stem.strokeWidth() % 2 / 2, t = n + r + h, g.stem[y]({ d: ["M", t, d, "L", t, k, "M", t, c, "L", t, e] }), q && (h = g.box.strokeWidth() % 2 / 2, c = Math.floor(c) + h, d = Math.floor(d) + h, n += h, x += h, g.box[y]({ d: ["M", n, d, "L", n, c, "L", x, c, "L", x, d, "L", n, d, "z"] })), z && (h = g.whiskers.strokeWidth() % 2 / 2, k += h, e += h, v = /%$/.test(z) ? r * parseFloat(z) / 100 : z / 2, g.whiskers[y]({ d: ["M", t - v, k, "L", t + v, k, "M", t - v, e, "L", t + v, e] })), f = Math.round(g.medianPlot), h = g.medianShape.strokeWidth() % 2 / 2, f += h, g.medianShape[y]({ d: ["M", n, f, "L", x, f] }))
                })
            }, setStackedPoints: v
        })
    })(w);
    (function (a) {
        var p = a.each, v = a.noop, u = a.seriesType, q = a.seriesTypes; u("errorbar", "boxplot", { color: "#000000", grouping: !1, linkedTo: ":previous", tooltip: { pointFormat: '\x3cspan style\x3d"color:{point.color}"\x3e\u25cf\x3c/span\x3e {series.name}: \x3cb\x3e{point.low}\x3c/b\x3e - \x3cb\x3e{point.high}\x3c/b\x3e\x3cbr/\x3e' }, whiskerWidth: null }, {
            type: "errorbar", pointArrayMap: ["low", "high"], toYData: function (a) { return [a.low, a.high] }, pointValKey: "high", doQuartiles: !1, drawDataLabels: q.arearange ? function () {
                var a =
                this.pointValKey; q.arearange.prototype.drawDataLabels.call(this); p(this.data, function (g) { g.y = g[a] })
            } : v, getColumnMetrics: function () { return this.linkedParent && this.linkedParent.columnMetrics || q.column.prototype.getColumnMetrics.call(this) }
        })
    })(w); (function (a) {
        var p = a.correctFloat, v = a.isNumber, u = a.pick, q = a.Point, r = a.Series, g = a.seriesType, m = a.seriesTypes; g("waterfall", "column", { dataLabels: { inside: !0 }, lineWidth: 1, lineColor: "#333333", dashStyle: "dot", borderColor: "#333333", states: { hover: { lineWidthPlus: 0 } } },
        {
            pointValKey: "y", showLine: !0, generatePoints: function () { var b = this.options.threshold, c, a, k, e; m.column.prototype.generatePoints.apply(this); k = 0; for (a = this.points.length; k < a; k++) c = this.points[k], e = this.processedYData[k], c.isSum ? c.y = p(e) : c.isIntermediateSum && (c.y = p(e - b), b = e) }, translate: function () {
                var b = this.options, c = this.yAxis, a, k, e, f, h, t, l, n, g, q, p = u(b.minPointLength, 5), r = p / 2, v = b.threshold, w = b.stacking, A; m.column.prototype.translate.apply(this); n = g = v; k = this.points; a = 0; for (b = k.length; a < b; a++) e = k[a], l =
                this.processedYData[a], f = e.shapeArgs, h = w && c.stacks[(this.negStacks && l < v ? "-" : "") + this.stackKey], A = this.getStackIndicator(A, e.x, this.index), q = u(h && h[e.x].points[A.key], [0, l]), t = Math.max(n, n + e.y) + q[0], f.y = c.translate(t, 0, 1, 0, 1), e.isSum ? (f.y = c.translate(q[1], 0, 1, 0, 1), f.height = Math.min(c.translate(q[0], 0, 1, 0, 1), c.len) - f.y) : e.isIntermediateSum ? (f.y = c.translate(q[1], 0, 1, 0, 1), f.height = Math.min(c.translate(g, 0, 1, 0, 1), c.len) - f.y, g = q[1]) : (f.height = 0 < l ? c.translate(n, 0, 1, 0, 1) - f.y : c.translate(n, 0, 1, 0, 1) - c.translate(n -
                l, 0, 1, 0, 1), n += h && h[e.x] ? h[e.x].total : l), 0 > f.height && (f.y += f.height, f.height *= -1), e.plotY = f.y = Math.round(f.y) - this.borderWidth % 2 / 2, f.height = Math.max(Math.round(f.height), .001), e.yBottom = f.y + f.height, f.height <= p && !e.isNull ? (f.height = p, f.y -= r, e.plotY = f.y, e.minPointLengthOffset = 0 > e.y ? -r : r) : e.minPointLengthOffset = 0, f = e.plotY + (e.negative ? f.height : 0), this.chart.inverted ? e.tooltipPos[0] = c.len - f : e.tooltipPos[1] = f
            }, processData: function (b) {
                var c = this.yData, a = this.options.data, k, e = c.length, f, h, t, l, n, g; h = f = t =
                l = this.options.threshold || 0; for (g = 0; g < e; g++) n = c[g], k = a && a[g] ? a[g] : {}, "sum" === n || k.isSum ? c[g] = p(h) : "intermediateSum" === n || k.isIntermediateSum ? c[g] = p(f) : (h += n, f += n), t = Math.min(h, t), l = Math.max(h, l); r.prototype.processData.call(this, b); this.options.stacking || (this.dataMin = t, this.dataMax = l)
            }, toYData: function (b) { return b.isSum ? 0 === b.x ? null : "sum" : b.isIntermediateSum ? 0 === b.x ? null : "intermediateSum" : b.y }, pointAttribs: function (b, c) {
                var a = this.options.upColor; a && !b.options.color && (b.color = 0 < b.y ? a : null); b = m.column.prototype.pointAttribs.call(this,
                b, c); delete b.dashstyle; return b
            }, getGraphPath: function () { return ["M", 0, 0] }, getCrispPath: function () { var b = this.data, c = b.length, a = this.graph.strokeWidth() + this.borderWidth, a = Math.round(a) % 2 / 2, k = this.xAxis.reversed, e = this.yAxis.reversed, f = [], h, g, l; for (l = 1; l < c; l++) { g = b[l].shapeArgs; h = b[l - 1].shapeArgs; g = ["M", h.x + (k ? 0 : h.width), h.y + b[l - 1].minPointLengthOffset + a, "L", g.x + (k ? h.width : 0), h.y + b[l - 1].minPointLengthOffset + a]; if (0 > b[l - 1].y && !e || 0 < b[l - 1].y && e) g[2] += h.height, g[5] += h.height; f = f.concat(g) } return f },
            drawGraph: function () { r.prototype.drawGraph.call(this); this.graph.attr({ d: this.getCrispPath() }) }, setStackedPoints: function () { var b = this.options, a, d; r.prototype.setStackedPoints.apply(this, arguments); a = this.stackedYData ? this.stackedYData.length : 0; for (d = 1; d < a; d++) b.data[d].isSum || b.data[d].isIntermediateSum || (this.stackedYData[d] += this.stackedYData[d - 1]) }, getExtremes: function () { if (this.options.stacking) return r.prototype.getExtremes.apply(this, arguments) }
        }, {
            getClassName: function () {
                var b = q.prototype.getClassName.call(this);
                this.isSum ? b += " highcharts-sum" : this.isIntermediateSum && (b += " highcharts-intermediate-sum"); return b
            }, isValid: function () { return v(this.y, !0) || this.isSum || this.isIntermediateSum }
        })
    })(w); (function (a) {
        var p = a.Series, v = a.seriesType, u = a.seriesTypes; v("polygon", "scatter", { marker: { enabled: !1, states: { hover: { enabled: !1 } } }, stickyTracking: !1, tooltip: { followPointer: !0, pointFormat: "" }, trackByArea: !0 }, {
            type: "polygon", getGraphPath: function () {
                for (var a = p.prototype.getGraphPath.call(this), r = a.length + 1; r--;) (r === a.length ||
                "M" === a[r]) && 0 < r && a.splice(r, 0, "z"); return this.areaPath = a
            }, drawGraph: function () { this.options.fillColor = this.color; u.area.prototype.drawGraph.call(this) }, drawLegendSymbol: a.LegendSymbolMixin.drawRectangle, drawTracker: p.prototype.drawTracker, setStackedPoints: a.noop
        })
    })(w); (function (a) {
        var p = a.arrayMax, v = a.arrayMin, u = a.Axis, q = a.color, r = a.each, g = a.isNumber, m = a.noop, b = a.pick, c = a.pInt, d = a.Point, k = a.Series, e = a.seriesType, f = a.seriesTypes; e("bubble", "scatter", {
            dataLabels: {
                formatter: function () { return this.point.z },
                inside: !0, verticalAlign: "middle"
            }, animationLimit: 250, marker: { lineColor: null, lineWidth: 1, fillOpacity: .5, radius: null, states: { hover: { radiusPlus: 0 } }, symbol: "circle" }, minSize: 8, maxSize: "20%", softThreshold: !1, states: { hover: { halo: { size: 5 } } }, tooltip: { pointFormat: "({point.x}, {point.y}), Size: {point.z}" }, turboThreshold: 0, zThreshold: 0, zoneAxis: "z"
        }, {
            pointArrayMap: ["y", "z"], parallelArrays: ["x", "y", "z"], trackerGroups: ["group", "dataLabelsGroup"], specialGroup: "group", bubblePadding: !0, zoneAxis: "z", directTouch: !0,
            pointAttribs: function (b, a) { var c = this.options.marker.fillOpacity; b = k.prototype.pointAttribs.call(this, b, a); 1 !== c && (b.fill = q(b.fill).setOpacity(c).get("rgba")); return b }, getRadii: function (b, a, c, d) {
                var e, f, h, k = this.zData, l = [], n = this.options, t = "width" !== n.sizeBy, m = n.zThreshold, p = a - b; f = 0; for (e = k.length; f < e; f++) h = k[f], n.sizeByAbsoluteValue && null !== h && (h = Math.abs(h - m), a = p = Math.max(a - m, Math.abs(b - m)), b = 0), g(h) ? h < b ? h = c / 2 - 1 : (h = 0 < p ? (h - b) / p : .5, t && 0 <= h && (h = Math.sqrt(h)), h = Math.ceil(c + h * (d - c)) / 2) : h = null, l.push(h);
                this.radii = l
            }, animate: function (b) { !b && this.points.length < this.options.animationLimit && (r(this.points, function (b) { var a = b.graphic, c; a && a.width && (c = { x: a.x, y: a.y, width: a.width, height: a.height }, a.attr({ x: b.plotX, y: b.plotY, width: 1, height: 1 }), a.animate(c, this.options.animation)) }, this), this.animate = null) }, translate: function () {
                var b, c = this.data, d, e, k = this.radii; f.scatter.prototype.translate.call(this); for (b = c.length; b--;) d = c[b], e = k ? k[b] : 0, g(e) && e >= this.minPxSize / 2 ? (d.marker = a.extend(d.marker, {
                    radius: e, width: 2 *
                    e, height: 2 * e
                }), d.dlBox = { x: d.plotX - e, y: d.plotY - e, width: 2 * e, height: 2 * e }) : d.shapeArgs = d.plotY = d.dlBox = void 0
            }, alignDataLabel: f.column.prototype.alignDataLabel, buildKDTree: m, applyZones: m
        }, { haloPath: function (b) { return d.prototype.haloPath.call(this, 0 === b ? 0 : (this.marker ? this.marker.radius || 0 : 0) + b) }, ttBelow: !1 }); u.prototype.beforePadding = function () {
            var d = this, e = this.len, f = this.chart, k = 0, m = e, q = this.isXAxis, u = q ? "xData" : "yData", w = this.min, z = {}, K = Math.min(f.plotWidth, f.plotHeight), A = Number.MAX_VALUE, F = -Number.MAX_VALUE,
            G = this.max - w, E = e / G, H = []; r(this.series, function (e) { var h = e.options; !e.bubblePadding || !e.visible && f.options.chart.ignoreHiddenSeries || (d.allowZoomOutside = !0, H.push(e), q && (r(["minSize", "maxSize"], function (b) { var a = h[b], d = /%$/.test(a), a = c(a); z[b] = d ? K * a / 100 : a }), e.minPxSize = z.minSize, e.maxPxSize = Math.max(z.maxSize, z.minSize), e = a.grep(e.zData, a.isNumber), e.length && (A = b(h.zMin, Math.min(A, Math.max(v(e), !1 === h.displayNegative ? h.zThreshold : -Number.MAX_VALUE))), F = b(h.zMax, Math.max(F, p(e)))))) }); r(H, function (b) {
                var a =
                b[u], c = a.length, e; q && b.getRadii(A, F, b.minPxSize, b.maxPxSize); if (0 < G) for (; c--;) g(a[c]) && d.dataMin <= a[c] && a[c] <= d.dataMax && (e = b.radii[c], k = Math.min((a[c] - w) * E - e, k), m = Math.max((a[c] - w) * E + e, m))
            }); H.length && 0 < G && !this.isLog && (m -= e, E *= (e + k - m) / e, r([["min", "userMin", k], ["max", "userMax", m]], function (a) { void 0 === b(d.options[a[0]], d[a[1]]) && (d[a[0]] += a[2] / E) }))
        }
    })(w); (function (a) {
        var p = a.each, v = a.pick, u = a.Series, q = a.seriesTypes, r = a.wrap, g = u.prototype, m = a.Pointer.prototype; a.polarExtended || (a.polarExtended = !0,
        g.searchPointByAngle = function (b) { var a = this.chart, d = this.xAxis.pane.center; return this.searchKDTree({ clientX: 180 + -180 / Math.PI * Math.atan2(b.chartX - d[0] - a.plotLeft, b.chartY - d[1] - a.plotTop) }) }, g.getConnectors = function (b, a, d, k) {
            var c, f, h, g, l, n, m, p; f = k ? 1 : 0; c = 0 <= a && a <= b.length - 1 ? a : 0 > a ? b.length - 1 + a : 0; a = 0 > c - 1 ? b.length - (1 + f) : c - 1; f = c + 1 > b.length - 1 ? f : c + 1; h = b[a]; f = b[f]; g = h.plotX; h = h.plotY; l = f.plotX; n = f.plotY; f = b[c].plotX; c = b[c].plotY; g = (1.5 * f + g) / 2.5; h = (1.5 * c + h) / 2.5; l = (1.5 * f + l) / 2.5; m = (1.5 * c + n) / 2.5; n = Math.sqrt(Math.pow(g -
            f, 2) + Math.pow(h - c, 2)); p = Math.sqrt(Math.pow(l - f, 2) + Math.pow(m - c, 2)); g = Math.atan2(h - c, g - f); m = Math.PI / 2 + (g + Math.atan2(m - c, l - f)) / 2; Math.abs(g - m) > Math.PI / 2 && (m -= Math.PI); g = f + Math.cos(m) * n; h = c + Math.sin(m) * n; l = f + Math.cos(Math.PI + m) * p; m = c + Math.sin(Math.PI + m) * p; f = { rightContX: l, rightContY: m, leftContX: g, leftContY: h, plotX: f, plotY: c }; d && (f.prevPointCont = this.getConnectors(b, a, !1, k)); return f
        }, r(g, "buildKDTree", function (b) {
            this.chart.polar && (this.kdByAngle ? this.searchPoint = this.searchPointByAngle : this.options.findNearestPointBy =
            "xy"); b.apply(this)
        }), g.toXY = function (b) { var a, d = this.chart, k = b.plotX; a = b.plotY; b.rectPlotX = k; b.rectPlotY = a; a = this.xAxis.postTranslate(b.plotX, this.yAxis.len - a); b.plotX = b.polarPlotX = a.x - d.plotLeft; b.plotY = b.polarPlotY = a.y - d.plotTop; this.kdByAngle ? (d = (k / Math.PI * 180 + this.xAxis.pane.options.startAngle) % 360, 0 > d && (d += 360), b.clientX = d) : b.clientX = b.plotX }, q.spline && (r(q.spline.prototype, "getPointSpline", function (b, a, d, k) {
            this.chart.polar ? k ? (b = this.getConnectors(a, k, !0, this.connectEnds), b = ["C", b.prevPointCont.rightContX,
            b.prevPointCont.rightContY, b.leftContX, b.leftContY, b.plotX, b.plotY]) : b = ["M", d.plotX, d.plotY] : b = b.call(this, a, d, k); return b
        }), q.areasplinerange && (q.areasplinerange.prototype.getPointSpline = q.spline.prototype.getPointSpline)), a.addEvent(u, "afterTranslate", function () {
            var b = this.chart, c, d; if (b.polar) {
                this.kdByAngle = b.tooltip && b.tooltip.shared; if (!this.preventPostTranslate) for (c = this.points, d = c.length; d--;) this.toXY(c[d]); this.hasClipCircleSetter || (this.hasClipCircleSetter = !!a.addEvent(this, "afterRender",
                function () { var c; b.polar && (c = this.yAxis.center, this.group.clip(b.renderer.clipCircle(c[0], c[1], c[2] / 2)), this.setClip = a.noop) }))
            }
        }, { order: 2 }), r(g, "getGraphPath", function (b, a) { var c = this, g, e, f; if (this.chart.polar) { a = a || this.points; for (g = 0; g < a.length; g++) if (!a[g].isNull) { e = g; break } !1 !== this.options.connectEnds && void 0 !== e && (this.connectEnds = !0, a.splice(a.length, 0, a[e]), f = !0); p(a, function (a) { void 0 === a.polarPlotY && c.toXY(a) }) } g = b.apply(this, [].slice.call(arguments, 1)); f && a.pop(); return g }), u = function (a,
        c) { var b = this.chart, g = this.options.animation, e = this.group, f = this.markerGroup, h = this.xAxis.center, m = b.plotLeft, l = b.plotTop; b.polar ? b.renderer.isSVG && (!0 === g && (g = {}), c ? (a = { translateX: h[0] + m, translateY: h[1] + l, scaleX: .001, scaleY: .001 }, e.attr(a), f && f.attr(a)) : (a = { translateX: m, translateY: l, scaleX: 1, scaleY: 1 }, e.animate(a, g), f && f.animate(a, g), this.animate = null)) : a.call(this, c) }, r(g, "animate", u), q.column && (q = q.column.prototype, q.polarArc = function (a, c, d, g) {
            var b = this.xAxis.center, f = this.yAxis.len; return this.chart.renderer.symbols.arc(b[0],
            b[1], f - c, null, { start: d, end: g, innerR: f - v(a, f) })
        }, r(q, "animate", u), r(q, "translate", function (a) { var b = this.xAxis, d = b.startAngleRad, g, e, f; this.preventPostTranslate = !0; a.call(this); if (b.isRadial) for (g = this.points, f = g.length; f--;) e = g[f], a = e.barX + d, e.shapeType = "path", e.shapeArgs = { d: this.polarArc(e.yBottom, e.plotY, a, a + e.pointWidth) }, this.toXY(e), e.tooltipPos = [e.plotX, e.plotY], e.ttBelow = e.plotY > b.center[1] }), r(q, "alignDataLabel", function (a, c, d, k, e, f) {
            this.chart.polar ? (a = c.rectPlotX / Math.PI * 180, null === k.align &&
            (k.align = 20 < a && 160 > a ? "left" : 200 < a && 340 > a ? "right" : "center"), null === k.verticalAlign && (k.verticalAlign = 45 > a || 315 < a ? "bottom" : 135 < a && 225 > a ? "top" : "middle"), g.alignDataLabel.call(this, c, d, k, e, f)) : a.call(this, c, d, k, e, f)
        })), r(m, "getCoordinates", function (a, c) {
            var b = this.chart, g = { xAxis: [], yAxis: [] }; b.polar ? p(b.axes, function (a) {
                var d = a.isXAxis, e = a.center, k = c.chartX - e[0] - b.plotLeft, e = c.chartY - e[1] - b.plotTop; g[d ? "xAxis" : "yAxis"].push({
                    axis: a, value: a.translate(d ? Math.PI - Math.atan2(k, e) : Math.sqrt(Math.pow(k, 2) + Math.pow(e,
                    2)), !0)
                })
            }) : g = a.call(this, c); return g
        }), a.SVGRenderer.prototype.clipCircle = function (b, c, d) { var g = a.uniqueKey(), e = this.createElement("clipPath").attr({ id: g }).add(this.defs); b = this.circle(b, c, d).add(e); b.id = g; b.clipPath = e; return b }, a.addEvent(a.Chart, "getAxes", function () { this.pane || (this.pane = []); p(a.splat(this.options.pane), function (b) { new a.Pane(b, this) }, this) }), a.addEvent(a.Chart, "afterDrawChartBox", function () { p(this.pane, function (a) { a.render() }) }), r(a.Chart.prototype, "get", function (b, c) {
            return a.find(this.pane,
            function (a) { return a.options.id === c }) || b.call(this, c)
        }))
    })(w)
});