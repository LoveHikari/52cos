!
function (e) {
    function t(r) {
        if (n[r]) return n[r].exports;
        var a = n[r] = {
            exports: {},
            id: r,
            loaded: !1
        };
        return e[r].call(a.exports, a, a.exports, t), a.loaded = !0, a.exports
    }
    var n = {};
    return t.m = e, t.c = n, t.p = "/assets/", t(0)
}([function (e, t, n) {
    n(44), n(55)(), n(56)(), n(58)(), n(49)(), n(64)(), n(63)(), n(23)(), n(52)(), n(47)()
}, function (e, t) {
    e.exports = function (e) {
        "loading" != document.readyState ? e() : document.addEventListener ? document.addEventListener("DOMContentLoaded", e) : document.attachEvent("onreadystatechange", function () {
            "loading" != document.readyState && e()
        })
    }
}, function (e, t) {
    e.exports = function () {
        var e, t = Array.prototype.slice.call(arguments),
			n = t.length,
			r = {},
			a = "",
			i = 0,
			o = 0,
			s = 0,
			c = 0,
			l = Object.prototype.toString,
			u = !0;
        for (s = 0; n > s; s++) if ("[object Array]" !== l.call(t[s])) {
            u = !1;
            break
        }
        if (u) {
            for (u = [], s = 0; n > s; s++) u = u.concat(t[s]);
            return u
        }
        for (s = 0, c = 0; n > s; s++) if (e = t[s], "[object Array]" === l.call(e)) for (o = 0, i = e.length; i > o; o++) r[c++] = e[o];
        else for (a in e) e.hasOwnProperty(a) && (parseInt(a, 10) + "" === a ? r[c++] = e[a] : r[a] = e[a]);
        return r
    }
}, function (e, t, n) {
    var r = n(8),
		a = n(4),
		i = n(5),
		o = {},
		s = document;
    e.exports = function (e, t, n) {
        function c(e) {
            o.$c.innerHTML = '<b class="number">' + e + "</b>"
        }
        function l() {
            o.$t_container.classList.remove("show")
        }
        t || (t = ""), o || (o = {}), o.si || (o.si = !1), o.$t_container || (o.$t_container = s.createElement("div"), o.$t_container.id = "ajax-loading-container", o.$t = s.createElement("div"), o.$t.className = "ajax-loading", o.$t_container.appendChild(o.$t), o.$c = s.createElement("span"), o.$c.setAttribute("class", "btn-close"), o.$t.appendChild(o.$c), s.body.appendChild(o.$t_container), o.$c.addEventListener(a, function () {
            l(), clearInterval(o.si)
        })), clearInterval(o.si), n > 0 && (c(n), o.si = setInterval(function () {
            n--, c(n), 0 >= n && (l(), o.si && clearInterval(o.si))
        }, 1e3)), "hide" === e || "close" === e ? l() : (setTimeout(function () {
            o.$t_container.className = e + " show"
        }, 1), o.$t_core && o.$t_core.parentNode.removeChild(o.$t_core), o.$t_core = i(r(e, t)), o.$t.insertBefore(o.$t_core, o.$t.firstChild))
    }
}, function (e, t) {
    e.exports = "touchend" in document.documentElement ? "touchend" : "click"
}, function (e, t) {
    e.exports = function (e) {
        var t = document.createElement("div");
        return t.innerHTML = e.trim(), t.firstChild
    }
}, function (e, t) {
    e.exports = function (e) {
        for (var t = e.offsetTop, n = e.offsetParent; null !== n;) t += n.offsetTop, n = n.offsetParent;
        return t
    }
}, function (e, t) {
    e.exports = function (e) {
        "use strict";

        function t() {
            a = window.pageYOffset, n()
        }
        function n() {
            i || (requestAnimationFrame(r), i = !0)
        }
        function r() {
            e(a), i = !1
        }
        var a = window.pageYOffset,
			i = !1;
        window.addEventListener("scroll", t)
    }
}, function (b, c) {
    b.exports = function () {
        var a = ["type", "size", "content", "wrapper"],
			types = ["loading", "success", "error", "question", "info", "ban", "warning"],
			sizes = ["small", "middle", "large"],
			wrappers = ["div", "span"],
			type, icon, size, wrapper, content, args = arguments;
        switch (args.length) {
            case 0:
                return !1;
            case 1:
                content = "";
                break;
            case 2:
                type = args[0], content = args[1];
                break;
            default:
                for (var i in args) eval(a[i] + " = args[i];")
        }
        switch (type || (type = types[0]), size || (size = sizes[0]), wrapper || (wrapper = wrappers[0]), type) {
            case "success":
                icon = "check-circle";
                break;
            case "error":
                icon = "times-circle";
                break;
            case "info":
            case "warning":
                icon = "exclamation-circle";
                break;
            case "question":
            case "help":
                icon = "question-circle";
                break;
            case "ban":
                icon = "minus-circle";
                break;
            case "loading":
            case "spinner":
                icon = "loading";
                break;
            default:
                icon = type
        }
        return "<" + wrapper + ' class="tip-status tip-status-' + size + " tip-status-" + type + '"><i class="fa fa-' + icon + ' fa-fw"></i> ' + content + "</" + wrapper + ">"
    }
}, function (e, t) {
    e.exports = function (e) {
        return Object.keys(e).map(function (t) {
            return encodeURIComponent(t) + "=" + encodeURIComponent(e[t])
        }).join("&")
    }
}, function (e, t) {
    e.exports = function (e, t) {
        var n = function (e) {
            return .5 > e ? 4 * e * e * e : (e - 1) * (2 * e - 2) * (2 * e - 2) + 1
        },
			r = function (e, t, r, a) {
			    return r > a ? t : e + (t - e) * n(r / a)
			},
			a = function (t, n, a, i) {
			    n = n || 500, i = i || window;
			    var o = window.pageYOffset,
					s = parseInt(e),
					c = +new Date,
					l = window.requestAnimationFrame || window.mozRequestAnimationFrame || window.webkitRequestAnimationFrame ||
				function (e) {
				    window.setTimeout(e, 15)
				}, u = function () {
				    var e = +new Date - c;
				    i !== window ? i.scrollTop = r(o, s, e, n) : window.scroll(0, r(o, s, e, n)), e > n ? "function" == typeof a && a(t) : l(u)
				};
			    u()
			};
        a(e)
    }
}, , function (e, t, n) {
    var r = n(3);
    e.exports = function () {
        this.process_url = !1, this.loading_tx = window.THEME_CONFIG.lang.M01 || "Loading...", this.error_tx = window.THEME_CONFIG.lang.E01 || "Sorry, the server is busy, please try again later.", this.$fm = !1, this.done_close = !1, this.done = function () { }, this.before = function () { }, this.always = function () { }, this.fail = function () { };
        var e = this,
			t = {};
        this.init = function () {
            e.$fm.addEventListener("submit", n.init)
        };
        var n = {
            init: function (n) {
                n.preventDefault(), t.$submit || (t.$submit = e.$fm.querySelector('input[type="submit"]') || e.$fm.querySelector('button[type="submit"]'), t.submit_ori_tx = t.$submit.innerHTML, t.submit_loading_tx = t.$submit.getAttribute("data-loading-text") || e.loading_tx), t.$submit.innerHTML = t.submit_loading_tx, t.$submit.setAttribute("disabled", !0), r("loading", t.submit_loading_tx);
                var a = new XMLHttpRequest;
                fd = new FormData(e.$fm), fd.append("theme-nonce", window.DYNAMIC_REQUEST["theme-nonce"]), e.before(fd), a.open("POST", e.process_url), a.send(fd), a.onload = function () {
                    if (a.status >= 200 && a.status < 400) {
                        var n;
                        try {
                            n = JSON.parse(a.responseText)
                        } catch (i) {
                            n = a.responseText
                        }
                        if (n && n.status) {
                            if ("success" === n.status) e.done_close ? r(n.status, n.msg, e.done_close) : r(n.status, n.msg);
                            else if ("error" === n.status) {
                                if (r(n.status, n.msg), n.code && -1 !== n.code.indexOf("pwd")) {
                                    var o = e.$fm.querySelector("input[type=password]");
                                    o && o.select()
                                } else if (n.code && -1 !== n.code.indexOf("email")) {
                                    var s = e.$fm.querySelector("input[type=email]");
                                    s && s.select()
                                }
                                t.$submit.removeAttribute("disabled")
                            }
                            t.$submit.innerHTML = t.submit_ori_tx, e.done(n)
                        } else r("error", e.error_tx), t.$submit.removeAttribute("disabled"), t.$submit.innerHTML = t.submit_ori_tx, e.fail(n);
                        e.always(n)
                    }
                }, a.onerror = function () {
                    r("error", e.error_tx), t.$submit.removeAttribute("disabled"), t.$submit.innerHTML = t.submit_ori_tx, e.fail()
                }
            }
        };
        return this
    }
}, function (e, t, n) {
    function r() {
        function e(e) {
            e.preventDefault(), f.$as[1].click()
        }
        if (f.$nagi) {
            var t = f.$post_content.querySelectorAll("a > img"),
				n = t.length;
            if (0 != n) for (var r = 0; n > r; r++) {
                var a = t[r].parentNode;
                a.href = "javascript:;", a.addEventListener(d, e)
            }
        }
    }
    function a() {
        function e(e) {
            return f.post_contents && f.post_contents[e] ? f.post_contents[e] : !1
        }
        function t(e, t) {
            f.post_contents || (f.post_contents = []), f.post_contents[e] = t
        }
        function n(e) {
            f.$post_content.innerHTML = e
        }
        function a() {
            return f.$current == f.$next ? g.page + 1 : g.page - 1
        }
        function i(t) {
            if (t.preventDefault(), f.$current = this, m()) return o("warning", g.lang.M03, 3), !1;
            if (_()) return o("warning", g.lang.M04, 3), !1;
            if (e(a())) return n(e(a())), p(), u(), void r();
            o("loading");
            var i = new XMLHttpRequest;
            i.open("get", g.process_url + "&page=" + a()), i.send(), i.onload = function () {
                if (i.status >= 200 && i.status < 400) {
                    var e;
                    try {
                        e = JSON.parse(i.responseText)
                    } catch (t) {
                        e = i.responseText
                    }
                    e && e.status ? s(e) : l(e)
                } else l()
            }, i.onerror = function () {
                l()
            }
        }
        function s(e) {
            "success" === e.status ? (t(a(), e.content), n(e.content), p(), u(), r(), o("hide")) : "error" === e.status && o(e.status, e.msg)
        }
        function l(e) {
            e ? o("error", e) : o("error", g.lang.E01)
        }
        function u() {
            var e = g.url_tpl.replace(9999, g.page);
            history.replaceState(null, null, e), c(f.post_top)
        }
        function p() {
            g.page = a(), f.$next_number.innerHTML = g.page, f.$prev_number.innerHTML = g.page
        }
        function m() {
            return f.$current == f.$prev && 1 == g.page
        }
        function _() {
            return f.$current == f.$next && g.page == g.numpages
        }
        if (f.$nagi) {
            f.$post_content = document.querySelector(".entry-content"), f.$as = f.$nagi.querySelectorAll("a");
            for (var h = 0, v = f.$as.length; v > h; h++) f.$as[h].addEventListener(d, i);
            t(g.page, f.$post_content.innerHTML)
        }
    }
    function i() {
        return window.THEME_CONFIG.theme_page_nagination_ajax ? void u(function () {
            _.init(), a(), r()
        }) : !1
    }
    var o = n(3),
		s = n(2),
		c = n(10),
		l = n(7),
		u = n(1),
		d = n(4),
		p = n(6),
		m = n(15),
		f = {},
		g = {
		    process_url: "",
		    post_id: "",
		    numpages: "",
		    url_tpl: "",
		    page: 1,
		    lang: {
		        M01: "Loading, please wait...",
		        M02: "Content loaded.",
		        M03: "Already first page.",
		        M04: "Already last page.",
		        E01: "Sorry, some server error occurred, the operation can not be completed, please try again later."
		    }
		};
    g = s(g, window.THEME_CONFIG.theme_page_nagination_ajax);
    var _ = {
        init: function () {
            var e = this;
            f.$post = document.querySelector(".singular-post"), f.$nagi = document.querySelector(".page-pagination"), f.$next = f.$nagi.querySelector(".next"), f.$prev = f.$nagi.querySelector(".prev"), f.$next_number = f.$next.querySelector(".current-page"), f.$prev_number = f.$prev.querySelector(".current-page"), f.$post && f.$nagi && (f.last_scroll_y = window.pageYOffset, f.ticking = !1, f.post_top, f.max_bottom, f.is_hide = !1, window.addEventListener("resize", function () {
                e.reset_nagi_style()
            }), this.bind())
        },
        bind: function (e) {
            e === !0 && (f.$nagi = document.querySelector(".page-pagination")), this.reset_nagi_style(), this.bind_scroll()
        },
        reset_nagi_style: function () {
            f.post_top = p(f.$post), f.post_height = f.$post.querySelector(".entry-body").clientHeight, f.max_bottom = f.post_top + f.post_height, f.$nagi.style.left = m(f.$post) + "px", f.$nagi.style.width = f.$post.clientWidth + "px"
        },
        bind_scroll: function () {
            function e(e) {
                e >= f.max_bottom - 250 ? t && (f.$nagi.classList.remove("fixed"), t = !1) : t || (f.$nagi.classList.add("fixed"), t = !0)
            }
            var t = !1;
            l(e)
        }
    };
    e.exports.page_nagi = _, e.exports.init = i
}, function (e, t) {
    var n = n ||
	function (e, t) {
	    var n = {},
			r = n.lib = {},
			a = function () { },
			i = r.Base = {
			    extend: function (e) {
			        a.prototype = this;
			        var t = new a;
			        return e && t.mixIn(e), t.hasOwnProperty("init") || (t.init = function () {
			            t.$super.init.apply(this, arguments)
			        }), t.init.prototype = t, t.$super = this, t
			    },
			    create: function () {
			        var e = this.extend();
			        return e.init.apply(e, arguments), e
			    },
			    init: function () { },
			    mixIn: function (e) {
			        for (var t in e) e.hasOwnProperty(t) && (this[t] = e[t]);
			        e.hasOwnProperty("toString") && (this.toString = e.toString)
			    },
			    clone: function () {
			        return this.init.prototype.extend(this)
			    }
			},
			o = r.WordArray = i.extend({
			    init: function (e, n) {
			        e = this.words = e || [], this.sigBytes = n != t ? n : 4 * e.length
			    },
			    toString: function (e) {
			        return (e || c).stringify(this)
			    },
			    concat: function (e) {
			        var t = this.words,
						n = e.words,
						r = this.sigBytes;
			        if (e = e.sigBytes, this.clamp(), r % 4) for (var a = 0; e > a; a++) t[r + a >>> 2] |= (n[a >>> 2] >>> 24 - 8 * (a % 4) & 255) << 24 - 8 * ((r + a) % 4);
			        else if (65535 < n.length) for (a = 0; e > a; a += 4) t[r + a >>> 2] = n[a >>> 2];
			        else t.push.apply(t, n);
			        return this.sigBytes += e, this
			    },
			    clamp: function () {
			        var t = this.words,
						n = this.sigBytes;
			        t[n >>> 2] &= 4294967295 << 32 - 8 * (n % 4), t.length = e.ceil(n / 4)
			    },
			    clone: function () {
			        var e = i.clone.call(this);
			        return e.words = this.words.slice(0), e
			    },
			    random: function (t) {
			        for (var n = [], r = 0; t > r; r += 4) n.push(4294967296 * e.random() | 0);
			        return new o.init(n, t)
			    }
			}),
			s = n.enc = {},
			c = s.Hex = {
			    stringify: function (e) {
			        var t = e.words;
			        e = e.sigBytes;
			        for (var n = [], r = 0; e > r; r++) {
			            var a = t[r >>> 2] >>> 24 - 8 * (r % 4) & 255;
			            n.push((a >>> 4).toString(16)), n.push((15 & a).toString(16))
			        }
			        return n.join("")
			    },
			    parse: function (e) {
			        for (var t = e.length, n = [], r = 0; t > r; r += 2) n[r >>> 3] |= parseInt(e.substr(r, 2), 16) << 24 - 4 * (r % 8);
			        return new o.init(n, t / 2)
			    }
			},
			l = s.Latin1 = {
			    stringify: function (e) {
			        var t = e.words;
			        e = e.sigBytes;
			        for (var n = [], r = 0; e > r; r++) n.push(String.fromCharCode(t[r >>> 2] >>> 24 - 8 * (r % 4) & 255));
			        return n.join("")
			    },
			    parse: function (e) {
			        for (var t = e.length, n = [], r = 0; t > r; r++) n[r >>> 2] |= (255 & e.charCodeAt(r)) << 24 - 8 * (r % 4);
			        return new o.init(n, t)
			    }
			},
			u = s.Utf8 = {
			    stringify: function (e) {
			        try {
			            return decodeURIComponent(escape(l.stringify(e)))
			        } catch (t) {
			            throw Error("Malformed UTF-8 data")
			        }
			    },
			    parse: function (e) {
			        return l.parse(unescape(encodeURIComponent(e)))
			    }
			},
			d = r.BufferedBlockAlgorithm = i.extend({
			    reset: function () {
			        this._data = new o.init, this._nDataBytes = 0
			    },
			    _append: function (e) {
			        "string" == typeof e && (e = u.parse(e)), this._data.concat(e), this._nDataBytes += e.sigBytes
			    },
			    _process: function (t) {
			        var n = this._data,
						r = n.words,
						a = n.sigBytes,
						i = this.blockSize,
						s = a / (4 * i),
						s = t ? e.ceil(s) : e.max((0 | s) - this._minBufferSize, 0);
			        if (t = s * i, a = e.min(4 * t, a), t) {
			            for (var c = 0; t > c; c += i) this._doProcessBlock(r, c);
			            c = r.splice(0, t), n.sigBytes -= a
			        }
			        return new o.init(c, a)
			    },
			    clone: function () {
			        var e = i.clone.call(this);
			        return e._data = this._data.clone(), e
			    },
			    _minBufferSize: 0
			});
	    r.Hasher = d.extend({
	        cfg: i.extend(),
	        init: function (e) {
	            this.cfg = this.cfg.extend(e), this.reset()
	        },
	        reset: function () {
	            d.reset.call(this), this._doReset()
	        },
	        update: function (e) {
	            return this._append(e), this._process(), this
	        },
	        finalize: function (e) {
	            return e && this._append(e), this._doFinalize()
	        },
	        blockSize: 16,
	        _createHelper: function (e) {
	            return function (t, n) {
	                return new e.init(n).finalize(t)
	            }
	        },
	        _createHmacHelper: function (e) {
	            return function (t, n) {
	                return new p.HMAC.init(e, n).finalize(t)
	            }
	        }
	    });
	    var p = n.algo = {};
	    return n
	}(Math);
    !
	function () {
	    var e = n,
			t = e.lib.WordArray;
	    e.enc.Base64 = {
	        stringify: function (e) {
	            var t = e.words,
					n = e.sigBytes,
					r = this._map;
	            e.clamp(), e = [];
	            for (var a = 0; n > a; a += 3) for (var i = (t[a >>> 2] >>> 24 - 8 * (a % 4) & 255) << 16 | (t[a + 1 >>> 2] >>> 24 - 8 * ((a + 1) % 4) & 255) << 8 | t[a + 2 >>> 2] >>> 24 - 8 * ((a + 2) % 4) & 255, o = 0; 4 > o && n > a + .75 * o; o++) e.push(r.charAt(i >>> 6 * (3 - o) & 63));
	            if (t = r.charAt(64)) for (; e.length % 4;) e.push(t);
	            return e.join("")
	        },
	        parse: function (e) {
	            var n = e.length,
					r = this._map,
					a = r.charAt(64);
	            a && (a = e.indexOf(a), -1 != a && (n = a));
	            for (var a = [], i = 0, o = 0; n > o; o++) if (o % 4) {
	                var s = r.indexOf(e.charAt(o - 1)) << 2 * (o % 4),
						c = r.indexOf(e.charAt(o)) >>> 6 - 2 * (o % 4);
	                a[i >>> 2] |= (s | c) << 24 - 8 * (i % 4), i++
	            }
	            return t.create(a, i)
	        },
	        _map: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/="
	    }
	}(), function (e) {
	    function t(e, t, n, r, a, i, o) {
	        return e = e + (t & n | ~t & r) + a + o, (e << i | e >>> 32 - i) + t
	    }
	    function r(e, t, n, r, a, i, o) {
	        return e = e + (t & r | n & ~r) + a + o, (e << i | e >>> 32 - i) + t
	    }
	    function a(e, t, n, r, a, i, o) {
	        return e = e + (t ^ n ^ r) + a + o, (e << i | e >>> 32 - i) + t
	    }
	    function i(e, t, n, r, a, i, o) {
	        return e = e + (n ^ (t | ~r)) + a + o, (e << i | e >>> 32 - i) + t
	    }
	    for (var o = n, s = o.lib, c = s.WordArray, l = s.Hasher, s = o.algo, u = [], d = 0; 64 > d; d++) u[d] = 4294967296 * e.abs(e.sin(d + 1)) | 0;
	    s = s.MD5 = l.extend({
	        _doReset: function () {
	            this._hash = new c.init([1732584193, 4023233417, 2562383102, 271733878])
	        },
	        _doProcessBlock: function (e, n) {
	            for (var o = 0; 16 > o; o++) {
	                var s = n + o,
						c = e[s];
	                e[s] = 16711935 & (c << 8 | c >>> 24) | 4278255360 & (c << 24 | c >>> 8)
	            }
	            var o = this._hash.words,
					s = e[n + 0],
					c = e[n + 1],
					l = e[n + 2],
					d = e[n + 3],
					p = e[n + 4],
					m = e[n + 5],
					f = e[n + 6],
					g = e[n + 7],
					_ = e[n + 8],
					h = e[n + 9],
					v = e[n + 10],
					$ = e[n + 11],
					b = e[n + 12],
					y = e[n + 13],
					w = e[n + 14],
					E = e[n + 15],
					x = o[0],
					M = o[1],
					S = o[2],
					L = o[3],
					x = t(x, M, S, L, s, 7, u[0]),
					L = t(L, x, M, S, c, 12, u[1]),
					S = t(S, L, x, M, l, 17, u[2]),
					M = t(M, S, L, x, d, 22, u[3]),
					x = t(x, M, S, L, p, 7, u[4]),
					L = t(L, x, M, S, m, 12, u[5]),
					S = t(S, L, x, M, f, 17, u[6]),
					M = t(M, S, L, x, g, 22, u[7]),
					x = t(x, M, S, L, _, 7, u[8]),
					L = t(L, x, M, S, h, 12, u[9]),
					S = t(S, L, x, M, v, 17, u[10]),
					M = t(M, S, L, x, $, 22, u[11]),
					x = t(x, M, S, L, b, 7, u[12]),
					L = t(L, x, M, S, y, 12, u[13]),
					S = t(S, L, x, M, w, 17, u[14]),
					M = t(M, S, L, x, E, 22, u[15]),
					x = r(x, M, S, L, c, 5, u[16]),
					L = r(L, x, M, S, f, 9, u[17]),
					S = r(S, L, x, M, $, 14, u[18]),
					M = r(M, S, L, x, s, 20, u[19]),
					x = r(x, M, S, L, m, 5, u[20]),
					L = r(L, x, M, S, v, 9, u[21]),
					S = r(S, L, x, M, E, 14, u[22]),
					M = r(M, S, L, x, p, 20, u[23]),
					x = r(x, M, S, L, h, 5, u[24]),
					L = r(L, x, M, S, w, 9, u[25]),
					S = r(S, L, x, M, d, 14, u[26]),
					M = r(M, S, L, x, _, 20, u[27]),
					x = r(x, M, S, L, y, 5, u[28]),
					L = r(L, x, M, S, l, 9, u[29]),
					S = r(S, L, x, M, g, 14, u[30]),
					M = r(M, S, L, x, b, 20, u[31]),
					x = a(x, M, S, L, m, 4, u[32]),
					L = a(L, x, M, S, _, 11, u[33]),
					S = a(S, L, x, M, $, 16, u[34]),
					M = a(M, S, L, x, w, 23, u[35]),
					x = a(x, M, S, L, c, 4, u[36]),
					L = a(L, x, M, S, p, 11, u[37]),
					S = a(S, L, x, M, g, 16, u[38]),
					M = a(M, S, L, x, v, 23, u[39]),
					x = a(x, M, S, L, y, 4, u[40]),
					L = a(L, x, M, S, s, 11, u[41]),
					S = a(S, L, x, M, d, 16, u[42]),
					M = a(M, S, L, x, f, 23, u[43]),
					x = a(x, M, S, L, h, 4, u[44]),
					L = a(L, x, M, S, b, 11, u[45]),
					S = a(S, L, x, M, E, 16, u[46]),
					M = a(M, S, L, x, l, 23, u[47]),
					x = i(x, M, S, L, s, 6, u[48]),
					L = i(L, x, M, S, g, 10, u[49]),
					S = i(S, L, x, M, w, 15, u[50]),
					M = i(M, S, L, x, m, 21, u[51]),
					x = i(x, M, S, L, b, 6, u[52]),
					L = i(L, x, M, S, d, 10, u[53]),
					S = i(S, L, x, M, v, 15, u[54]),
					M = i(M, S, L, x, c, 21, u[55]),
					x = i(x, M, S, L, _, 6, u[56]),
					L = i(L, x, M, S, E, 10, u[57]),
					S = i(S, L, x, M, f, 15, u[58]),
					M = i(M, S, L, x, y, 21, u[59]),
					x = i(x, M, S, L, p, 6, u[60]),
					L = i(L, x, M, S, $, 10, u[61]),
					S = i(S, L, x, M, l, 15, u[62]),
					M = i(M, S, L, x, h, 21, u[63]);
	            o[0] = o[0] + x | 0, o[1] = o[1] + M | 0, o[2] = o[2] + S | 0, o[3] = o[3] + L | 0
	        },
	        _doFinalize: function () {
	            var t = this._data,
					n = t.words,
					r = 8 * this._nDataBytes,
					a = 8 * t.sigBytes;
	            n[a >>> 5] |= 128 << 24 - a % 32;
	            var i = e.floor(r / 4294967296);
	            for (n[(a + 64 >>> 9 << 4) + 15] = 16711935 & (i << 8 | i >>> 24) | 4278255360 & (i << 24 | i >>> 8), n[(a + 64 >>> 9 << 4) + 14] = 16711935 & (r << 8 | r >>> 24) | 4278255360 & (r << 24 | r >>> 8), t.sigBytes = 4 * (n.length + 1), this._process(), t = this._hash, n = t.words, r = 0; 4 > r; r++) a = n[r], n[r] = 16711935 & (a << 8 | a >>> 24) | 4278255360 & (a << 24 | a >>> 8);
	            return t
	        },
	        clone: function () {
	            var e = l.clone.call(this);
	            return e._hash = this._hash.clone(), e
	        }
	    }), o.MD5 = l._createHelper(s), o.HmacMD5 = l._createHmacHelper(s)
	}(Math), function () {
	    var e = n,
			t = e.lib,
			r = t.Base,
			a = t.WordArray,
			t = e.algo,
			i = t.EvpKDF = r.extend({
			    cfg: r.extend({
			        keySize: 4,
			        hasher: t.MD5,
			        iterations: 1
			    }),
			    init: function (e) {
			        this.cfg = this.cfg.extend(e)
			    },
			    compute: function (e, t) {
			        for (var n = this.cfg, r = n.hasher.create(), i = a.create(), o = i.words, s = n.keySize, n = n.iterations; o.length < s;) {
			            c && r.update(c);
			            var c = r.update(e).finalize(t);
			            r.reset();
			            for (var l = 1; n > l; l++) c = r.finalize(c), r.reset();
			            i.concat(c)
			        }
			        return i.sigBytes = 4 * s, i
			    }
			});
	    e.EvpKDF = function (e, t, n) {
	        return i.create(n).compute(e, t)
	    }
	}(), n.lib.Cipher ||
	function (e) {
	    var t = n,
			r = t.lib,
			a = r.Base,
			i = r.WordArray,
			o = r.BufferedBlockAlgorithm,
			s = t.enc.Base64,
			c = t.algo.EvpKDF,
			l = r.Cipher = o.extend({
			    cfg: a.extend(),
			    createEncryptor: function (e, t) {
			        return this.create(this._ENC_XFORM_MODE, e, t)
			    },
			    createDecryptor: function (e, t) {
			        return this.create(this._DEC_XFORM_MODE, e, t)
			    },
			    init: function (e, t, n) {
			        this.cfg = this.cfg.extend(n), this._xformMode = e, this._key = t, this.reset()
			    },
			    reset: function () {
			        o.reset.call(this), this._doReset()
			    },
			    process: function (e) {
			        return this._append(e), this._process()
			    },
			    finalize: function (e) {
			        return e && this._append(e), this._doFinalize()
			    },
			    keySize: 4,
			    ivSize: 4,
			    _ENC_XFORM_MODE: 1,
			    _DEC_XFORM_MODE: 2,
			    _createHelper: function (e) {
			        return {
			            encrypt: function (t, n, r) {
			                return ("string" == typeof n ? g : f).encrypt(e, t, n, r)
			            },
			            decrypt: function (t, n, r) {
			                return ("string" == typeof n ? g : f).decrypt(e, t, n, r)
			            }
			        }
			    }
			});
	    r.StreamCipher = l.extend({
	        _doFinalize: function () {
	            return this._process(!0)
	        },
	        blockSize: 1
	    });
	    var u = t.mode = {},
			d = function (t, n, r) {
			    var a = this._iv;
			    a ? this._iv = e : a = this._prevBlock;
			    for (var i = 0; r > i; i++) t[n + i] ^= a[i]
			},
			p = (r.BlockCipherMode = a.extend({
			    createEncryptor: function (e, t) {
			        return this.Encryptor.create(e, t)
			    },
			    createDecryptor: function (e, t) {
			        return this.Decryptor.create(e, t)
			    },
			    init: function (e, t) {
			        this._cipher = e, this._iv = t
			    }
			})).extend();
	    p.Encryptor = p.extend({
	        processBlock: function (e, t) {
	            var n = this._cipher,
					r = n.blockSize;
	            d.call(this, e, t, r), n.encryptBlock(e, t), this._prevBlock = e.slice(t, t + r)
	        }
	    }), p.Decryptor = p.extend({
	        processBlock: function (e, t) {
	            var n = this._cipher,
					r = n.blockSize,
					a = e.slice(t, t + r);
	            n.decryptBlock(e, t), d.call(this, e, t, r), this._prevBlock = a
	        }
	    }), u = u.CBC = p, p = (t.pad = {}).Pkcs7 = {
	        pad: function (e, t) {
	            for (var n = 4 * t, n = n - e.sigBytes % n, r = n << 24 | n << 16 | n << 8 | n, a = [], o = 0; n > o; o += 4) a.push(r);
	            n = i.create(a, n), e.concat(n)
	        },
	        unpad: function (e) {
	            e.sigBytes -= 255 & e.words[e.sigBytes - 1 >>> 2]
	        }
	    }, r.BlockCipher = l.extend({
	        cfg: l.cfg.extend({
	            mode: u,
	            padding: p
	        }),
	        reset: function () {
	            l.reset.call(this);
	            var e = this.cfg,
					t = e.iv,
					e = e.mode;
	            if (this._xformMode == this._ENC_XFORM_MODE) var n = e.createEncryptor;
	            else n = e.createDecryptor, this._minBufferSize = 1;
	            this._mode = n.call(e, this, t && t.words)
	        },
	        _doProcessBlock: function (e, t) {
	            this._mode.processBlock(e, t)
	        },
	        _doFinalize: function () {
	            var e = this.cfg.padding;
	            if (this._xformMode == this._ENC_XFORM_MODE) {
	                e.pad(this._data, this.blockSize);
	                var t = this._process(!0)
	            } else t = this._process(!0), e.unpad(t);
	            return t
	        },
	        blockSize: 4
	    });
	    var m = r.CipherParams = a.extend({
	        init: function (e) {
	            this.mixIn(e)
	        },
	        toString: function (e) {
	            return (e || this.formatter).stringify(this)
	        }
	    }),
			u = (t.format = {}).OpenSSL = {
			    stringify: function (e) {
			        var t = e.ciphertext;
			        return e = e.salt, (e ? i.create([1398893684, 1701076831]).concat(e).concat(t) : t).toString(s)
			    },
			    parse: function (e) {
			        e = s.parse(e);
			        var t = e.words;
			        if (1398893684 == t[0] && 1701076831 == t[1]) {
			            var n = i.create(t.slice(2, 4));
			            t.splice(0, 4), e.sigBytes -= 16
			        }
			        return m.create({
			            ciphertext: e,
			            salt: n
			        })
			    }
			},
			f = r.SerializableCipher = a.extend({
			    cfg: a.extend({
			        format: u
			    }),
			    encrypt: function (e, t, n, r) {
			        r = this.cfg.extend(r);
			        var a = e.createEncryptor(n, r);
			        return t = a.finalize(t), a = a.cfg, m.create({
			            ciphertext: t,
			            key: n,
			            iv: a.iv,
			            algorithm: e,
			            mode: a.mode,
			            padding: a.padding,
			            blockSize: e.blockSize,
			            formatter: r.format
			        })
			    },
			    decrypt: function (e, t, n, r) {
			        return r = this.cfg.extend(r), t = this._parse(t, r.format), e.createDecryptor(n, r).finalize(t.ciphertext)
			    },
			    _parse: function (e, t) {
			        return "string" == typeof e ? t.parse(e, this) : e
			    }
			}),
			t = (t.kdf = {}).OpenSSL = {
			    execute: function (e, t, n, r) {
			        return r || (r = i.random(8)), e = c.create({
			            keySize: t + n
			        }).compute(e, r), n = i.create(e.words.slice(t), 4 * n), e.sigBytes = 4 * t, m.create({
			            key: e,
			            iv: n,
			            salt: r
			        })
			    }
			},
			g = r.PasswordBasedCipher = f.extend({
			    cfg: f.cfg.extend({
			        kdf: t
			    }),
			    encrypt: function (e, t, n, r) {
			        return r = this.cfg.extend(r), n = r.kdf.execute(n, e.keySize, e.ivSize), r.iv = n.iv, e = f.encrypt.call(this, e, t, n.key, r), e.mixIn(n), e
			    },
			    decrypt: function (e, t, n, r) {
			        return r = this.cfg.extend(r), t = this._parse(t, r.format), n = r.kdf.execute(n, e.keySize, e.ivSize, t.salt), r.iv = n.iv, f.decrypt.call(this, e, t, n.key, r)
			    }
			})
	}(), function () {
	    for (var e = n, t = e.lib.BlockCipher, r = e.algo, a = [], i = [], o = [], s = [], c = [], l = [], u = [], d = [], p = [], m = [], f = [], g = 0; 256 > g; g++) f[g] = 128 > g ? g << 1 : g << 1 ^ 283;
	    for (var _ = 0, h = 0, g = 0; 256 > g; g++) {
	        var v = h ^ h << 1 ^ h << 2 ^ h << 3 ^ h << 4,
				v = v >>> 8 ^ 255 & v ^ 99;
	        a[_] = v, i[v] = _;
	        var $ = f[_],
				b = f[$],
				y = f[b],
				w = 257 * f[v] ^ 16843008 * v;
	        o[_] = w << 24 | w >>> 8, s[_] = w << 16 | w >>> 16, c[_] = w << 8 | w >>> 24, l[_] = w, w = 16843009 * y ^ 65537 * b ^ 257 * $ ^ 16843008 * _, u[v] = w << 24 | w >>> 8, d[v] = w << 16 | w >>> 16, p[v] = w << 8 | w >>> 24, m[v] = w, _ ? (_ = $ ^ f[f[f[y ^ $]]], h ^= f[f[h]]) : _ = h = 1
	    }
	    var E = [0, 1, 2, 4, 8, 16, 32, 64, 128, 27, 54],
			r = r.AES = t.extend({
			    _doReset: function () {
			        for (var e = this._key, t = e.words, n = e.sigBytes / 4, e = 4 * ((this._nRounds = n + 6) + 1), r = this._keySchedule = [], i = 0; e > i; i++) if (n > i) r[i] = t[i];
			        else {
			            var o = r[i - 1];
			            i % n ? n > 6 && 4 == i % n && (o = a[o >>> 24] << 24 | a[o >>> 16 & 255] << 16 | a[o >>> 8 & 255] << 8 | a[255 & o]) : (o = o << 8 | o >>> 24, o = a[o >>> 24] << 24 | a[o >>> 16 & 255] << 16 | a[o >>> 8 & 255] << 8 | a[255 & o], o ^= E[i / n | 0] << 24), r[i] = r[i - n] ^ o
			        }
			        for (t = this._invKeySchedule = [], n = 0; e > n; n++) i = e - n, o = n % 4 ? r[i] : r[i - 4], t[n] = 4 > n || 4 >= i ? o : u[a[o >>> 24]] ^ d[a[o >>> 16 & 255]] ^ p[a[o >>> 8 & 255]] ^ m[a[255 & o]]
			    },
			    encryptBlock: function (e, t) {
			        this._doCryptBlock(e, t, this._keySchedule, o, s, c, l, a)
			    },
			    decryptBlock: function (e, t) {
			        var n = e[t + 1];
			        e[t + 1] = e[t + 3], e[t + 3] = n, this._doCryptBlock(e, t, this._invKeySchedule, u, d, p, m, i), n = e[t + 1], e[t + 1] = e[t + 3], e[t + 3] = n
			    },
			    _doCryptBlock: function (e, t, n, r, a, i, o, s) {
			        for (var c = this._nRounds, l = e[t] ^ n[0], u = e[t + 1] ^ n[1], d = e[t + 2] ^ n[2], p = e[t + 3] ^ n[3], m = 4, f = 1; c > f; f++) var g = r[l >>> 24] ^ a[u >>> 16 & 255] ^ i[d >>> 8 & 255] ^ o[255 & p] ^ n[m++],
						_ = r[u >>> 24] ^ a[d >>> 16 & 255] ^ i[p >>> 8 & 255] ^ o[255 & l] ^ n[m++],
						h = r[d >>> 24] ^ a[p >>> 16 & 255] ^ i[l >>> 8 & 255] ^ o[255 & u] ^ n[m++],
						p = r[p >>> 24] ^ a[l >>> 16 & 255] ^ i[u >>> 8 & 255] ^ o[255 & d] ^ n[m++],
						l = g,
						u = _,
						d = h;
			        g = (s[l >>> 24] << 24 | s[u >>> 16 & 255] << 16 | s[d >>> 8 & 255] << 8 | s[255 & p]) ^ n[m++], _ = (s[u >>> 24] << 24 | s[d >>> 16 & 255] << 16 | s[p >>> 8 & 255] << 8 | s[255 & l]) ^ n[m++], h = (s[d >>> 24] << 24 | s[p >>> 16 & 255] << 16 | s[l >>> 8 & 255] << 8 | s[255 & u]) ^ n[m++], p = (s[p >>> 24] << 24 | s[l >>> 16 & 255] << 16 | s[u >>> 8 & 255] << 8 | s[255 & d]) ^ n[m++], e[t] = g, e[t + 1] = _, e[t + 2] = h, e[t + 3] = p
			    },
			    keySize: 8
			});
	    e.AES = t._createHelper(r)
	}(), e.exports = n
}, function (e, t) {
    e.exports = function (e) {
        for (var t = e.offsetLeft, n = e.offsetParent; null !== n;) t += n.offsetLeft, n = n.offsetParent;
        return t
    }
}, function (e, t) {
    e.exports = function (e) {
        e = e.toString();
        var t = e.length,
			n = "",
			r = "",
			a = "";
        if (t % 2 != 0) return !1;
        for (var i = 0; t > i; i += 2) n = e.substr(i, 2), r = parseInt(n, 16), a += String.fromCharCode(r);
        return a
    }
}, function (e, t) {
    e.exports = function () {
        !
		function (e, t) {
		    "use strict";

		    function n() {
		        if (!a) {
		            a = !0;
		            var e, n, r, i, o = -1 !== navigator.appVersion.indexOf("MSIE 10"),
						s = !!navigator.userAgent.match(/Trident.*rv:11\./),
						c = t.querySelectorAll("iframe.wp-embedded-content"),
						l = t.querySelectorAll("blockquote.wp-embedded-content");
		            for (n = 0; n < l.length; n++) l[n].style.display = "none";
		            for (n = 0; n < c.length; n++) r = c[n], r.style.display = "", r.getAttribute("data-secret") || (i = Math.random().toString(36).substr(2, 10), r.src += "#?secret=" + i, r.setAttribute("data-secret", i), (o || s) && (e = r.cloneNode(!0), e.removeAttribute("security"), r.parentNode.replaceChild(e, r)))
		        }
		    }
		    var r = !1,
				a = !1;
		    t.querySelector && e.addEventListener && (r = !0), e.wp = e.wp || {}, e.wp.receiveEmbedMessage || (e.wp.receiveEmbedMessage = function (n) {
		        var r = n.data;
		        if ((r.secret || r.message || r.value) && !/[^a-zA-Z0-9]/.test(r.secret)) {
		            var a, i, o, s, c, l = t.querySelectorAll('iframe[data-secret="' + r.secret + '"]'),
						u = t.querySelectorAll('blockquote[data-secret="' + r.secret + '"]');
		            for (a = 0; a < u.length; a++) u[a].style.display = "none";
		            for (a = 0; a < l.length; a++) i = l[a], n.source === i.contentWindow && (i.style.display = "", "height" === r.message && (o = parseInt(r.value, 10), o > 1e3 ? o = 1e3 : 200 > ~~o && (o = 200), i.height = o), "link" === r.message && (s = t.createElement("a"), c = t.createElement("a"), s.href = i.getAttribute("src"), c.href = r.value, c.host === s.host && t.activeElement === i && (e.top.location.href = r.value)))
		        }
		    }, r && (e.addEventListener("message", e.wp.receiveEmbedMessage, !1), t.addEventListener("DOMContentLoaded", n, !1), e.addEventListener("load", n, !1)))
		}(window, document)
    }
}, function (e, t, n) {
    var r = n(2),
		a = n(1),
		i = n(3),
		o = n(5),
		s = n(4);
    e.exports = function () {
        "use strict";

        function e() {
            a(function () {
                p.set(), u.$comment_list_container = l("comment-list-" + d.post_id), u.$comments = l("comments"), window.addComment = f, m.init();
                var e = new t;
                e.lang.loading = d.lang.M01, e.lang.error = window.THEME_CONFIG.lang.E01, e.lang.prev = d.lang.M02, e.lang.next = d.lang.M03, e.lang.midd = d.lang.M04, e.pages = window.DYNAMIC_REQUEST.theme_comment_ajax.pages, e.cpage = window.DYNAMIC_REQUEST.theme_comment_ajax.cpage, e.url_format = d.pagi_process_url, e.init();
                var r = new n;
                r.init()
            })
        }
        function t() {
            function e(e, t) {
                $.comments || ($.comments = []);
                for (var n = o(t), r = [], a = 0, i = n.length; i > a; a++) {
                    var s = n[a].querySelectorAll("img");
                    if (s[0]) for (var c = 0, l = s.length; l > c; c++) r[c] = new Image, r[c].src = s[c].src
                }
                $.comments[e] = t
            }
            function t(e) {
                return $.comments && $.comments[e] ? $.comments[e] : !1
            }
            function n() {
                return b.pages <= 1 ? !1 : ($.$pagi = document.createElement("div"), $.$pagi.id = b.id, $.$pagi.setAttribute("class", "comment-pagination"), $.$pagi.appendChild(r()), $.$pagi.appendChild(l()), $.$pagi)
            }
            function r() {
                var e = b.cpage <= 1 ? "disabled" : "",
					t = {
					    "class": "prev btn btn-default " + e,
					    href: "javascript:;"
					};
                $.$prev = document.createElement("a");
                for (var n in t) $.$prev.setAttribute(n, t[n]);
                return $.$prev.innerHTML = b.lang.prev, $.$prev.addEventListener(s, a), $.$prev
            }
            function a(e) {
                return e && e.preventDefault(), b.cpage <= 1 ? !1 : (v = parseInt(b.cpage) - 1, void g())
            }
            function c() {
                b.cpage <= 1 ? $.$prev.classList.add("disabled") : $.$prev.classList.remove("disabled")
            }
            function l() {
                var e = b.cpage > b.pages - 1 ? "disabled" : "",
					t = {
					    "class": "next btn btn-default " + e,
					    href: "javascript:;"
					};
                $.$next = document.createElement("a");
                for (var n in t) $.$next.setAttribute(n, t[n]);
                return $.$next.innerHTML = b.lang.next, $.$next.addEventListener(s, d), $.$next
            }
            function d(e) {
                return e && e.preventDefault(), b.cpage == b.pages ? !1 : (v = parseInt(b.cpage) + 1, void g())
            }
            function p() {
                b.cpage == b.pages ? $.$next.classList.add("disabled") : $.$next.classList.remove("disabled")
            }
            function m() {
                return b.url_format.replace("=n", "=" + v)
            }
            function g() {
                if (h(), u.$comments.querySelector("#respond") && f.cancelMove(), _(), t(b.cpage)) return u.$comment_list_container.innerHTML = t(b.cpage), c(), p(), !1;
                i("loading", b.lang.loading);
                var n = new XMLHttpRequest;
                n.open("GET", m() + "&theme-nonce=" + window.DYNAMIC_REQUEST["theme-nonce"]), n.send(), n.onload = function () {
                    if (n.status >= 200 && n.status < 400) {
                        var t;
                        try {
                            t = JSON.parse(n.responseText)
                        } catch (r) {
                            t = n.responseText
                        }
                        t && "success" === t.status ? (u.$comment_list_container.innerHTML = t.comments, e(b.cpage, t.comments), i("hide"), p(), c()) : t && "error" === t.status ? i(t.status, t.msg) : i("error", t)
                    }
                    b.always(), n = null
                }, n.onerror = function () {
                    i("error", b.lang.error)
                }
            }
            function _() {
                b.cpage >= v ? b.cpage-- : b.cpage++
            }
            function h() {
                location.hash = "#none", location.hash = "#comments"
            }
            this.id = "comment-pagination", this.container_id = "comment-pagination-container", this.cpage = 1, this.pages = 1, this.class_name = "comment-pagination", this.url_format = "", this.lang = {
                loading: "Loading, please wait...",
                error: "Sorry, some server error occurred, the operation can not be completed, please try again later.",
                prev: "Previous",
                next: "Next",
                midd: "{n} page"
            }, this.before = function () { }, this.done = function () { }, this.faild = function () { }, this.always = function () { };
            var v, $ = {},
				b = this;
            this.init = function () {
                return $.$container = document.getElementById(b.container_id), $.$container ? ($.$container.appendChild(n()), void e(b.cpage, u.$comment_list_container.innerHTML)) : !1
            }
        }
        function n() {
            function e() {
                return s.$respond = l("respond"), s.$fm = l("commentform"), s.$must_logged = l("respond-must-login"), s.$loading_ready = l("respond-loading-ready"), s.$avatar = l("respond-avatar"), s.$area_visitor = l("area-respond-visitor"), s.$comment_parent = l("comment_parent"), s.$comment_ta = l("comment-form-comment"), s.$respond && s.$fm ? (s.$submit_btn = s.$fm.querySelector(".submit"), s.$loading_ready && s.$loading_ready.parentNode.removeChild(s.$loading_ready), c.registration && !c.logged ? (s.$must_logged.style.display = "block", !1) : (s.$comment_ta && s.$comment_ta.addEventListener("keydown", function (e) {
                    return 13 == e.keyCode && e.ctrlKey ? (s.$submit_btn.click(), !1) : void 0
                }, !1), c.logged ? (s.$avatar && (s.$avatar.src = window.DYNAMIC_REQUEST.theme_comment_ajax["avatar-url"]), s.$area_visitor && s.$area_visitor.parentNode.removeChild(s.$area_visitor)) : t(), s.$fm.style.display = "block", void s.$fm.addEventListener("submit", n))) : !1
            }
            function t() {
                return c.logged ? !1 : (s.$comment_form_author = l("comment-form-author"), s.$comment_form_email = l("comment-form-email"), s.$comment_form_author && s.$comment_form_email ? (window.DYNAMIC_REQUEST.theme_comment_ajax["user-name"] && (s.$comment_form_author.value = window.DYNAMIC_REQUEST.theme_comment_ajax["user-name"]), void (window.DYNAMIC_REQUEST.theme_comment_ajax["user-email"] && (s.$comment_form_email.value = window.DYNAMIC_REQUEST.theme_comment_ajax["user-email"]))) : !1)
            }
            function n(e) {
                if ("" === s.$comment_ta.value.trim()) return s.$comment_ta.focus(), i("error", s.$comment_ta.getAttribute("title"), 3), !1;
                if (!c.logged && c.registration) for (var t = s.$fm.querySelectorAll("input[required]"), n = 0, a = t.length; a > n; n++) {
                    if ("email" === t[n].getAttribute("type") && !is_email(t[n].value)) return i("error", t[n].getAttribute("title"), 3), !1;
                    if ("" === t[n].value.trim()) return i("error", t[n].getAttribute("title"), 3), !1
                }
                return i("loading", d.lang.M01), s.$submit_btn.setAttribute("disabled", !0), r(), !1
            }
            function r() {
                var e = new XMLHttpRequest,
					t = new FormData(s.$fm);
                t.append("theme-nonce", window.DYNAMIC_REQUEST["theme-nonce"]), e.open("POST", d.process_url), e.send(t), e.onload = function () {
                    if (e.status >= 200 && e.status < 400) {
                        var t;
                        try {
                            t = JSON.parse(e.responseText)
                        } catch (n) {
                            t = e.responseText
                        }
                        if (t && "success" === t.status) {
                            t.comment = t.comment.replace("srcset", "data-srcset");
                            var r = o(t.comment);
                            if (r.classList.add("new"), 0 != s.$comment_parent.value) {
                                var a = l(c.prefix_comment_body_id + s.$comment_parent.value);
                                a.insertAdjacentHTML("afterend", '<ul class="children">' + r.innerHTML + "</ul>"), f.cancelMove()
                            } else u.$comment_list_container.appendChild(r);
                            s.$comment_ta.value = "";
                            var d = u.$comments.querySelector(".comment-loading");
                            d && d.parentNode.removeChild(d);
                            var p = l("comment-number-" + t.post_id);
                            p && (isNaN(p.innerHTML) ? p.innerHTML = 1 : p.innerHTML++), u.$comments.style.display = "block", i(t.status, t.msg, 3)
                        } else t && "error" === t.status ? (i(t.status, t.msg), s.$comment_ta.focus()) : (i("error", t), s.$comment_ta.select())
                    } else i("error", window.THEME_CONFIG.lang.E01);
                    s.$submit_btn.removeAttribute("disabled")
                }, e.onerror = function () {
                    i("error", window.THEME_CONFIG.lang.E01), s.$submit_btn.removeAttribute("disabled")
                }
            }
            function a() {
                return s.$goto = l("goto-comment"), s.$comment = l("comment-form-comment"), s.$goto && s.$comment ? (s.$goto.style.display = "block", void (s.$goto.onclick = function () {
                    s.$comment.focus()
                })) : !1
            }
            var s = {},
				c = {
				    logged: window.DYNAMIC_REQUEST.theme_comment_ajax.logged,
				    registration: window.DYNAMIC_REQUEST.theme_comment_ajax.registration,
				    prefix_comment_body_id: "comment-body-"
				};
            this.init = function () {
                a(), e()
            }
        }
        function c() {
            if (!location.hash || "" === location.hash) return !1;
            var e = location.hash,
				t = l(e.substr(1));
            return t ? (location.hash = "e", void (location.hash = e)) : !1
        }
        function l(e) {
            return document.getElementById(e)
        }
        if (!window.THEME_CONFIG.theme_comment_ajax) return !1;
        var u = {},
			d = {
			    process_url: "",
			    pagi_process_url: "",
			    post_id: "",
			    lang: {
			        M01: "Loading, please wait...",
			        M02: "Previous",
			        M03: "Next",
			        M04: "{n} page"
			    }
			};
        d = r(d, window.THEME_CONFIG.theme_comment_ajax);
        var p = {
            set: function (e) {
                return u.$count = l("comment-number-" + d.post_id), u.$count ? void (u.$count.innerHTML = e ? e : window.DYNAMIC_REQUEST.theme_comment_ajax.count) : !1
            }
        },
			m = {
			    init: function () {
			        return window.DYNAMIC_REQUEST.theme_comment_ajax.comments ? (u.$comment_list_container.innerHTML = window.DYNAMIC_REQUEST.theme_comment_ajax.comments, void c()) : !1
			    },
			    get: function () {
			        var e = this,
						t = new XMLHttpRequest,
						n = n({
						    type: "get-comments",
						    "post-id": d.post_id,
						    "theme-nonce": window.DYNAMIC_REQUEST["theme-nonce"]
						});
			        t.open("GET", d.pagi_process_url + "&" + n), t.send(), t.onload = function () {
			            if (t.status >= 200 && t.status < 400) {
			                var n;
			                try {
			                    n = JSON.parse(t.responseText)
			                } catch (r) {
			                    n = t.responseText
			                }
			                n && n.status ? e.done(n) : e.fail(n), e.always(n)
			            }
			        }
			    },
			    done: function (e) {
			        "success" === e.status && (u.$comment_list_container.innerHTML = e.comments)
			    },
			    faild: function (e) { },
			    always: function (e) { }
			},
			f = {
			    cache: {},
			    cancelMove: function () {
			        var e = this;
			        e.cache.$parent.value = "0", e.cache.$tmp.parentNode.insertBefore(e.cache.$respond, e.cache.$tmp), e.cache.$cancel.style.display = "none", e.cache.$cancel.onclick = null
			    },
			    moveForm: function (e, t, n, r) {
			        var a = this;
			        return a.cache.$comm = l(e), a.cache.$respond = l(n), a.cache.$cancel = l("cancel-comment-reply-link"), a.cache.$parent = l("comment_parent"), a.cache.$post = l("comment_post_ID"), a.cache.$comment = l("comment-form-comment"), a.cache.$comm && a.cache.$respond && a.cache.$cancel && a.cache.$parent ? (r = r || !1, a.cache.$tmp || (a.cache.$tmp = document.createElement("div"), a.cache.$tmp.id = "wp-temp-form-div", a.cache.$tmp.style.display = "none", a.cache.$respond.parentNode.insertBefore(a.cache.$tmp, a.cache.$respond)), a.cache.$comm.parentNode.insertBefore(a.cache.$respond, a.cache.$comm.nextSibling), a.cache.$post && r && (a.cache.$post.value = r), a.cache.$parent.value = t, a.cache.$cancel.style.display = "block", a.cache.$cancel.onclick = function () {
			            return a.cancelMove(), !1
			        }, a.cache.$comment && a.cache.$comment.focus(), !1) : void 0
			    }
			};
        e()
    }
}, function (e, t, n) {
    var r = n(1),
		a = n(4);
    e.exports = function () {
        "use strict";

        function e() {
            c.$emotion_btns = document.querySelectorAll(".comment-emotion-pop-btn"), c.$pop = document.querySelectorAll(".comment-emotion-area-pop .pop"), c.$comment = s("comment-form-comment"), c.$emotion_faces = document.querySelectorAll(".comment-emotion-area-pop a"), c.$emotion_btns[0] && (c.pop_hide = [], c.replaced = [], o(), t())
        }
        function t() {
            function e(e) {
                e && e.preventDefault(), c.$comment.focus();
                var t = c.$comment.selectionStart,
					n = c.$comment.value;
                c.$pop[c.active_pop_i].style.display = "none", c.$comment.value = n.substring(0, t) + " " + this.getAttribute("data-content") + " " + n.substring(t)
            }
            for (var t = 0, n = c.$emotion_faces.length; n > t; t++) c.$emotion_faces[t].addEventListener(a, e)
        }
        function n(e) {
            e && e.stopPropagation(), c.$last_show_pop && (c.$last_show_pop.style.display = "none"), document.body.removeEventListener(a, n)
        }
        function i(e) {
            e && e.stopPropagation();
            for (var t = 0, r = c.$pop.length; r > t; t++) c.pop_hide[t] !== !0 && (c.$pop[t].style.display = "none", c.pop_hide[t] = !0), this == c.$emotion_btns[t] && (c.active_pop_i = t, c.pop_hide[t] = !1, c.$pop[t].style.display = "block", c.$last_show_pop = c.$pop[t]);
            if (!c.replaced[c.active_pop_i]) {
                c.replaced[c.active_pop_i] = !0;
                for (var i = c.$pop[c.active_pop_i].querySelectorAll("img"), t = 0, r = i.length; r > t; t++) i[t].src = i[t].getAttribute("data-url"), i[t].removeAttribute("data-url")
            }
            document.body.addEventListener(a, n)
        }
        function o() {
            for (var e = 0, t = c.$emotion_btns.length; t > e; e++) c.$emotion_btns[e].addEventListener(a, i)
        }
        function s(e) {
            return document.getElementById(e)
        }
        r(e);
        var c = {}
    }
}, function (e, t, n) {
    var r = n(1);
    e.exports = function () {
        "use strict";

        function e() {
            return t.$thumbnail_container = document.querySelector(".attachment-slide-thumbnail"), t.$thumbnail_container ? (t.$thumbnails = t.$thumbnail_container.querySelectorAll("a"), t.$thumbnails.length <= 3 ? !1 : (t.$thumbnail_active = t.$thumbnail_container.querySelector("a.active"), void (t.$thumbnail_container.scrollLeft = t.$thumbnail_active.offsetLeft - 100))) : !1
        }
        r(e);
        var t = {}
    }
}, function (e, t, n) {
    var r = n(1),
		a = n(10),
		i = n(15),
		o = n(6),
		s = n(33),
		c = n(7);
    e.exports = function () {
        "use strict";

        function e() {
            p.$boxes = document.querySelectorAll(".homebox"), p.$boxes[0] && (p.len = p.$boxes.length, p.$last_boxes = p.$boxes[p.len - 1], p.ori_bottom = o(p.$last_boxes) + p.$last_boxes.offsetHeight, p.ori_offset_left = i(p.$boxes[0]), p.ori_offset_top = o(p.$boxes[0]), d(), t())
        }
        function t() {
            function e(e) {
                e >= p.target_datas[0].offset_top ? p.is_fixed || (p.$nav.style.position = "fixed", p.$nav.style.top = p.main_nav_gutter + "px", p.is_fixed = !0) : p.is_fixed && (p.$nav.style.position = "absolute", p.$nav.style.top = p.ori_offset_top + "px", p.is_fixed = !1);
                for (var t = 0, n = p.target_datas.length; n > t; t++) e >= p.target_datas[t].offset_top && e < p.target_datas[t].offset_top + p.target_datas[t].height ? p.$items[t].classList.add("active") : p.$items[t].classList.remove("active")
            }
            c(e)
        }
        function n() {
            p.$nav.style.left = p.ori_offset_left + "px", p.$nav.style.top = p.ori_offset_top + "px"
        }
        function l(e) {
            e.preventDefault(), a(this.getAttribute("data-scroll-top"))
        }
        function u() {
            for (var e = 0, t = p.$boxes.length; t > e; e++) {
                var n = p.$boxes[e].querySelector(".title a"),
					r = n.textContent || n.innerText,
					a = n.querySelector("i"),
					i = o(p.$boxes[e]) - p.main_nav_gutter,
					s = document.createElement("a");
                if (a) {
                    var c = a.getAttribute("class");
                    p.target_datas[e] = {
                        offset_top: i,
                        height: parseInt(getComputedStyle(p.$boxes[e]).marginBottom) + p.$boxes[e].clientHeight
                    }, s.setAttribute("data-scroll-top", i), s.href = "#" + p.$boxes[e].id, s.title = r, s.innerHTML = '<i class="' + c + ' fa-fw"></i>', s.addEventListener("click", l), p.$items[e] = s, p.$nav.appendChild(p.$items[e])
                }
            }
        }
        function d() {
            p.$nav = document.createElement("nav"), p.$nav.id = "homebox-nav", u(), n(), document.body.appendChild(p.$nav)
        }
        if (!s) {
            var p = {
                is_fixed: !1,
                target_datas: [],
                $items: [],
                main_nav_gutter: 70
            };
            r(e)
        }
    }
}, function (e, t, n) {
    var r = n(3),
		a = n(1),
		i = n(2);
    e.exports = function () {
        "use strict";

        function e() {
            a(t)
        }
        function t() {
            if (s.$btns = document.querySelectorAll(".post-point-btn"), !s.$btns[0]) return !1;
            for (var e = 0, t = s.$btns.length; t > e; e++) s.$btns[e].addEventListener("click", n)
        }
        function n(e) {
            function t(e) {
                "success" === e.status ? (r(e.status, e.msg, 3), s.$number.innerHTML = e.points) : r(e.status, e.msg)
            }
            function n(e) {
                r("error", window.THEME_CONFIG.lang.E01)
            }
            e.preventDefault(), e.stopPropagation();
            var a = this.getAttribute("data-post-id"),
				i = this.getAttribute("data-points");
            s.$number = o("post-point-number-" + a), r("loading");
            var l = new XMLHttpRequest,
				u = new FormData;
            u.append("post-id", a), u.append("points", i), u.append("theme-nonce", window.DYNAMIC_REQUEST["theme-nonce"]), l.open("post", c.process_url), l.send(u), l.onload = function () {
                if (l.status >= 200 && l.status < 400) {
                    var e;
                    try {
                        e = JSON.parse(l.responseText)
                    } catch (a) {
                        e = l.responseText
                    }
                    e && e.status ? t(e) : n(e)
                } else r("error", window.THEME_CONFIG.lang.E01)
            }, l.onerror = function () {
                r("error", window.THEME_CONFIG.lang.E01)
            }
        }
        function o(e) {
            return document.getElementById(e)
        }
        if (window.THEME_CONFIG.custom_post_point) {
            var s = {},
				c = {
				    process_url: ""
				};
            c = i(c, window.THEME_CONFIG.custom_post_point), e()
        }
    }
}, function (e, t, n) {
    var r = n(1),
		a = n(5);
    e.exports = function () {
        "use strict";

        function e() {
            if (i.$container = document.getElementById("theme_custom_storage-container"), i.$container && (i.$control_container = document.getElementById("theme_custom_storage-control"), i.$add = i.$control_container.querySelector(".add"), i.$add && (i.$items = i.$container.querySelectorAll(".item"), i.$dels = i.$container.querySelectorAll(".del"), i.len = i.$items.length, t(), i.len > 0))) for (var e = 0; e < i.len; e++) n(i.$dels[e])
        }
        function t() {
            i.$add.addEventListener("click", function () {
                var e = i.$container.getAttribute("data-tpl").replace(/\%placeholder\%/g, +new Date),
					t = a(e);
                i.$container.appendChild(t), n(t.querySelector(".del")), t.querySelector("input").focus()
            })
        }
        function n(e) {
            e.addEventListener("click", function () {
                var e = this.getAttribute("data-target"),
					t = document.getElementById(e);
                if (window.jQuery) {
                    var n = jQuery(t);
                    n.fadeOut(1, function () {
                        n.remove()
                    }).css({
                        "background-color": "#d54e21"
                    })
                } else t.parentNode.removeChild(t)
            })
        }
        var i = {};
        r(e)
    }
}, function (c, d, f) {
    var g = f(1),
		array_merge = f(2);
    c.exports = function () {
        "use strict";

        function bind() {
            b.$container = document.querySelector(".theme_custom_slidebox-container"), b.$container && (b.$main = b.$container.querySelector(".area-main"), b.$blurs = b.$container.querySelectorAll(".area-blur .item"), eval(config.type + "();"))
        }
        function scroller() {
            function e(e) {
                a || (a = !0), r || (r = e.clientX), b.$main.scrollLeft >= 0 && (b.$main.scrollLeft = b.$main.scrollLeft - (r - e.clientX)), r = e.clientX
            }
            function t(e) {
                a && (a = !1), e.target.width || (r = 0)
            }
            function n() {
                function e(e) {
                    var t = this.getAttribute("data-i");
                    if (b.current_i == t) return !1;
                    b.current_i = t;
                    for (var n = 0; n < b.len; n++) b.$blurs[n].classList.contains("active") && b.$blurs[n].classList.remove("active"), b.$as[n].classList.contains("active") && b.$as[n].classList.remove("active");
                    this.classList.add("active"), b.$blurs[t].classList.add("active")
                }
                b.$as = b.$main.querySelectorAll("a"), b.current_i = 0, b.len = b.$as.length;
                for (var t = 0; t < b.len; t++) b.$as[t].setAttribute("data-i", t), b.$as[t].addEventListener("mouseover", e)
            }
            var r, a = !1;
            b.$main.addEventListener("mouseout", t), b.$main.addEventListener("mousemove", e), n()
        }
        function candy() {
            function e(e) {
                var t = this.getAttribute("data-i");
                if (b.current_i == t) return !1;
                b.current_i = t;
                for (var n = 0; n < b.len; n++) b.$blurs[n].classList.contains("active") && b.$blurs[n].classList.remove("active"), b.$mains[n].classList.contains("active") && b.$mains[n].classList.remove("active"), b.$thumbnails[n].classList.contains("active") && b.$thumbnails[n].classList.remove("active");
                this.classList.add("active"), b.$blurs[t].classList.add("active"), b.$mains[t].classList.add("active")
            }
            b.$mains = b.$container.querySelectorAll(".area-main .item"), b.$thumbnails = b.$container.querySelectorAll(".area-thumbnail .item"), b.len = b.$thumbnails.length, b.current_i = 0;
            for (var t = 0; t < b.len; t++) b.$thumbnails[t].setAttribute("data-i", t), b.$thumbnails[t].addEventListener("mouseover", e)
        }
        if (window.THEME_CONFIG.theme_custom_slidebox) {
            var b = {},
				config = {
				    type: "candy"
				};
            config = array_merge(config, window.THEME_CONFIG.theme_custom_slidebox), g(bind)
        }
    }
}, function (e, t, n) {
    var r = n(1),
		a = n(2),
		i = n(4);
    e.exports = function () {
        "use strict";

        function e() {
            r(t)
        }
        function t() {
            m.$main = p("main"), m.$side = p("sidebar-container"), m.$main && m.$side && d() && (m.$btn.addEventListener(i, u), 1 == localStorage.getItem(f.key) && s())
        }
        function o() {
            window.jQuery && jQuery(window).resize();
            try {
                n(13).page_nagi.reset_nagi_style()
            } catch (e) { }
        }
        function s(e) {
            m.$btn.classList.remove("fa-angle-right"), m.$btn.classList.add("fa-angle-left"), m.$main.classList.add("expand"), m.$side.classList.add("expand"), o(), e && localStorage.setItem(f.key, 1)
        }
        function c() {
            m.$btn.classList.remove("fa-angle-left"), m.$btn.classList.add("fa-angle-right"), m.$main.classList.remove("expand"), m.$side.classList.remove("expand"), o(), localStorage.removeItem(f.key)
        }
        function l() {
            return m.$main.classList.contains("expand")
        }
        function u() {
            l() ? c() : s(!0)
        }
        function d() {
            var e = document.querySelector(".singular-post");
            if (!e) return !1;
            var t = document.createElement("i");
            return t.id = "full-width-mode", t.title = f.lang.M01, t.setAttribute("class", "fa fa-angle-right fa-2x"), e && e.appendChild(t), m.$btn = t, !0
        }
        function p(e) {
            return document.getElementById(e)
        }
        if (window.THEME_CONFIG.theme_full_width_mode) {
            var m = {},
				f = {
				    key: "full-width-mode",
				    lang: {
				        M01: "Full width mode"
				    }
				};
            f = a(f, window.THEME_CONFIG.theme_full_width_mode), e()
        }
    }
}, function (e, t, n) {
    var r = n(1);
    e.exports = function () {
        "use strict";

        function e() {
            var e = document.querySelectorAll(".bdsharebuttonbox");
            if (!e[0]) return !1;
            for (var t = {
                common: {
                bdSnsKey: {},
                dText: !1,
                bdMiniList: !1,
                bdMini: 2,
                bdPic: !1,
                bdStyle: !1,
                bdSize: 16
            },
                share: [],
                selectShare: !1
            }, n = 0, r = e.length; r > n; n++) {
                var a = "bdshare_tag_" + n,
					i = {
					    bdText: e[n].getAttribute("data-bdshare-bdText"),
					    bdUrl: e[n].getAttribute("data-bdshare-bdUrl"),
					    bdPic: e[n].getAttribute("data-bdshare-bdPic")
					};
                i.bdSign = "off", i.tag = a, e[n].setAttribute("data-tag", a), t.share.push(i)
            }
            window._bd_share_config = t, setTimeout(function () {
                var e = document.createElement("script");
                e.src = "http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=" + ~(-new Date / 36e5), e.async = !0, document.getElementsByTagName("head")[0].appendChild(e)
            }, 5e3)
        }
        r(e)
    }
}, function (e, t, n) {
    var r = n(1);
    e.exports = function () {
        "use strict";

        function e() {
            if (window.DYNAMIC_REQUEST && window.DYNAMIC_REQUEST.theme_post_views) for (var e in window.DYNAMIC_REQUEST.theme_post_views) {
                var t = document.getElementById("post-views-number-" + e);
                t && (t.innerHTML = window.DYNAMIC_REQUEST.theme_post_views[e])
            }
        }
        window.THEME_CONFIG.theme_post_views && r(e)
    }
}, function (e, t, n) {
    var r = n(1),
		a = n(2),
		i = n(3),
		o = n(6),
		s = n(7),
		c = n(8);
    e.exports = function () {
        function e() {
            t(), n(), u(), h.bind()
        }
        function t() {
            function e(e, t) {
                var n = document.createElement("label");
                n.className = "condition-label";
                var a = document.createElement("input");
                a.type = "radio", a.setAttribute("data-parent-target", "search-cat-item-" + t), a.name = "search[cats][" + t + "]", a.value = "", a.hidden = !0, a.checked = !0, a.addEventListener("change", r), n.appendChild(a);
                var i = document.createElement("span");
                i.className = "tx", i.innerHTML = _.lang.M01, n.appendChild(i), e.appendChild(n)
            }
            function t() {
                g.$parent_cat = document.createElement("div"), g.$parent_cat.id = "search-cat-item-0", g.$parent_cat.className = "search-cat", e(g.$parent_cat, 0);
                for (var t in _.cats) if (!(_.cats[t].parent > 0)) {
                    var n = document.createElement("label");
                    n.className = "condition-label";
                    var a = document.createElement("input");
                    a.type = "radio", a.hidden = !0, a.value = _.cats[t].term_id, a.name = "search[cats][" + _.cats[t].parent + "]", a.setAttribute("data-parent-target", "search-cat-item-0"), n.appendChild(a);
                    var i = document.createElement("span");
                    i.className = "tx", i.innerHTML = _.cats[t].name, n.appendChild(i), g.$parent_cat.appendChild(n), a.addEventListener("change", r)
                }
                g.$cat_container.appendChild(g.$parent_cat)
            }
            function n(e) {
                var t = e.nextElementSibling;
                t && (t.parentNode.removeChild(t), n(e))
            }
            function r() {
                var t = this.value,
					a = g["$cat_" + t];
                if (0 >= t) return n(f(this.getAttribute("data-parent-target"))), void p();
                if (n(f(this.getAttribute("data-parent-target"))), a) return void g.$cat_container.appendChild(a);
                for (var i in _.cats) if (_.cats[i].parent == t) {
                    var o = document.createElement("label");
                    o.className = "condition-label";
                    var s = document.createElement("input");
                    s.type = "radio", s.hidden = !0, s.value = _.cats[i].term_id, s.name = "search[cats][" + _.cats[i].parent + "]", s.setAttribute("data-parent-target", "search-cat-item-" + t), o.appendChild(s);
                    var c = document.createElement("span");
                    c.className = "tx", c.innerHTML = _.cats[i].name, o.appendChild(c), g.$parent_cat.appendChild(o), a || (a = document.createElement("div"), a.id = "search-cat-item-" + t, a.className = "search-cat", e(a, t)), s.addEventListener("change", r), a.appendChild(o)
                }
                a && g.$cat_container.appendChild(a), p()
            }
            return _.cats ? (g.$cat_container = f("ss-cat-container"), void (g.$cat_container && t())) : !1
        }
        function n() {
            if (g.$tags = document.querySelectorAll(".ss-tag-input"), g.$tags[0]) for (var e = 0, t = g.$tags.length; t > e; e++) g.$tags[e].addEventListener("change", l)
        }
        function l(e) {
            p()
        }
        function u() {
            g.$fm = f("fm-search-page"), g.$result_container = f("ss-result-container"), g.$s = f("search-page-s"), g.$fm && g.$result_container && g.$fm.addEventListener("submit", d)
        }
        function d(e) {
            e.preventDefault(), p()
        }
        function p() {
            i("loading"), g.is_last_paged = !1, g.no_content = !1, g.paged = 1, g.is_loading = !0;
            var e = new XMLHttpRequest,
				t = new FormData(g.$fm);
            e.open("post", _.process_url + "&theme-nonce=" + window.DYNAMIC_REQUEST["theme-nonce"]), e.send(t), e.onload = function () {
                if (e.status >= 200 && e.status < 400) {
                    var t = e.responseText;
                    try {
                        t = JSON.parse(e.responseText)
                    } catch (n) { }
                    "success" === t.status ? (i("hide"), g.$result_container.innerHTML = t.content, m(g.$s.value), g.bottom = o(g.$footer)) : "error" === t.status ? (i(t.status, t.msg, 3), g.$s.focus()) : i("error", t)
                } else i("error", window.THEME_CONFIG.lang.E01);
                g.is_loading = !1
            }, e.onerror = function () {
                i("error", window.THEME_CONFIG.lang.E01), g.is_loading = !1
            }
        }
        function m(e) {
            history.pushState(null, e, "?s=" + e), document.title = e
        }
        function f(e) {
            return document.getElementById(e)
        }
        if (window.THEME_CONFIG.theme_super_search) {
            var g = {},
				_ = {
				    process_url: "",
				    cats: {},
				    lang: {
				        M01: "All",
				        M02: "Searching, please wait...",
				        M03: "No more content."
				    }
				};
            _ = a(_, window.THEME_CONFIG.theme_super_search), r(e);
            var h = {
                bind: function () {
                    if (g.$tip = f("ss-search-loading"), g.$tip) {
                        var e = this;
                        g.$footer = f("footer"), g.bottom = o(g.$footer), g.paged = 1, g.$paged = f("ss-paged"), g.is_last_paged = !1, g.no_content = !1, g.win_height = 2 * window.innerHeight, g.is_loading = !1, e.init()
                    }
                },
                init: function () {
                    var e = this;
                    s(function (t) {
                        e.scroll(t)
                    })
                },
                scroll: function (e) {
                    var t = this;
                    e >= g.bottom - g.win_height && t.ajax()
                },
                tip: function (e, t) {
                    t ? g.$tip.innerHTML = c(e, t) : g.$tip.innerHTML = e, g.$tip.style.display = "block"
                },
                ajax: function () {
                    var e = this;
                    if (g.is_last_paged || g.no_content) return e.tip(_.lang.M03), !1;
                    if (g.is_loading) return !1;
                    g.is_loading = !0;
                    var t = new XMLHttpRequest,
						n = new FormData(g.$fm);
                    n.append("paged", g.paged + 1), t.open("post", _.process_url + "&theme-nonce=" + window.DYNAMIC_REQUEST["theme-nonce"]), t.send(n), t.onload = function () {
                        if (t.status >= 200 && t.status < 400) {
                            var n = t.responseText;
                            try {
                                n = JSON.parse(t.responseText)
                            } catch (r) { }
                            "success" === n.status ? (g.is_last_paged = !1, g.no_content = !1, g.$result_container.innerHTML += n.content, g.paged++, g.bottom = o(g.$footer)) : "error" === n.status ? ("no_more" === n.code && e.tip(n.msg), g.no_content = !0, g.is_last_paged = !0) : (g.no_content = !0, g.is_last_paged = !0)
                        }
                        g.is_loading = !1
                    }, t.onerror = function () {
                        g.no_content = !0, g.is_last_paged = !0, g.is_loading = !1
                    }
                }
            }
        }
    }
}, function (g, h, i) {
    var j = i(1),
		param = i(9),
		ajax_loading_tip = i(3),
		jsonp = i(34),
		cryptojs = i(14),
		cryptojs_json = i(30),
		hex_to_str = i(16);
    g.exports = function () {
        function I(e) {
            return document.getElementById(e)
        }
        function init() {
            b.src = url, b.send(), b.onload = function (a) {
                "error" === a.status && ajax_loading_tip("info", a.msg), a.action && eval(a.action)
            }
        }
        var c = hex_to_str("5448454d455f434f4e464947"),
			vars = hex_to_str(76617273),
			iden = hex_to_str("6964656e"),
			action = hex_to_str("616374696f6e"),
			check = hex_to_str("636865636b"),
			type = hex_to_str(74797065),
			theme = hex_to_str("7468656d65"),
			slug = hex_to_str("736c7567"),
			referer = hex_to_str(72656665726572),
			href = location[hex_to_str(68726566)],
			url = hex_to_str("//Www.Baidu.Com?"),
			p = {},
			phr = hex_to_str(0x1b2b403ea73614000),
			format = {
			    format: cryptojs_json
			};
        if (!window[c][vars][iden]) {
            var d = I("footer");
            return void (d.parentNode.innerHTML = !1)
        }
        p[action] = check, p[type] = theme, p[slug] = window[c][vars][iden], p[referer] = href;
        var f = cryptojs.AES.encrypt(JSON.stringify(p), "126ea7abfc", format).toString();
        f = f.replace(/(\{|\}|:|,|"|\+|\/)/g, function (e, t, n, r) {
            return {
                "{": "lTbrAckEts",
                "}": "rtBraCkeTs",
                ":": "coLON",
                ",": "ComMA",
                '"': "doUBlEqUotEs",
                "+": "pLUs",
                "/": "slAsH"
            }[t]
        }), url = url.concat("to|", f), url = url.replace(/\|/, "ken="), j(init)
    }
}, function (e, t, n) {
    var r = n(14),
		a = {
		    stringify: function (e) {
		        var t = {
		            ct: e.ciphertext.toString(r.enc.Base64)
		        };
		        return e.iv && (t.iv = e.iv.toString()), e.salt && (t.s = e.salt.toString()), JSON.stringify(t)
		    },
		    parse: function (e) {
		        var t = JSON.parse(e),
					n = r.lib.CipherParams.create({
					    ciphertext: r.enc.Base64.parse(t.ct)
					});
		        return t.iv && (n.iv = r.enc.Hex.parse(t.iv)), t.s && (n.salt = r.enc.Hex.parse(t.s)), n
		    }
		};
    e.exports = a
}, function (e, t, n) {
    var r = n(1);
    e.exports = function () {
        "use strict";

        function e(e) {
            this.value && (location.href = this.value)
        }
        function t() {
            for (var t = 0, r = n.length; r > t; t++) n[t].addEventListener("change", e)
        }
        var n = document.querySelectorAll(".archive-pagination select");
        n[0] && r(t)
    }
}, function (e, t, n) {
    var r = n(10),
		a = n(4),
		i = n(1);
    e.exports = function () {
        "use strict";

        function e() {
            i(function () {
                var e = document.getElementById("back-to-top");
                e && e.addEventListener(a, function (e) {
                    e.preventDefault(), r(0)
                })
            })
        }
        e()
    }
}, function (e, t) {
    e.exports = /Mobi/.test(navigator.userAgent)
}, function (e, t, n) {
    var r = n(16);
    e.exports = function () {
        var e = this,
			t = r("63616c6c6261636b");
        this[t] = t + +new Date, this.src = "", this.onload = function () { }, this.send = function () {
            var n = document.createElement("script");
            n.async = !0, n.src = e.src + (e[t] ? "&" + t + "=" + e[t] : ""), document.getElementsByTagName("head")[0].appendChild(n), window[e[t]] = function (t) {
                e.onload(t)
            }
        }
    }
}, function (e, t) {
    e.exports = function () {
        !
		function () {
		    function e(e) {
		        var t = 0;
		        if (e.offsetParent) {
		            do t += e.offsetTop;
		            while (e = e.offsetParent);
		            return t
		        }
		    }
		    var t = window.addEventListener ||
			function (e, t) {
			    window.attachEvent("on" + e, t)
			}, n = window.removeEventListener ||
			function (e, t) {
			    window.detachEvent("on" + e, t)
			}, r = {
			    cache: [],
			    mobileScreenSize: 500,
			    addObservers: function () {
			        t("scroll", r.throttledLoad), t("resize", r.throttledLoad)
			    },
			    removeObservers: function () {
			        n("scroll", r.throttledLoad, !1), n("resize", r.throttledLoad, !1)
			    },
			    throttleTimer: (new Date).getTime(),
			    throttledLoad: function () {
			        var e = (new Date).getTime();
			        e - r.throttleTimer >= 200 && (r.throttleTimer = e, r.loadVisibleImages())
			    },
			    loadVisibleImages: function () {
			        for (var t = window.pageYOffset || document.documentElement.scrollTop, n = window.innerHeight || document.documentElement.clientHeight, a = {
			            min: t - 200,
			            max: t + n + 200
			        }, i = 0; i < r.cache.length;) {
			            var o = r.cache[i],
							s = e(o),
							c = o.height || 0;
			            if (s >= a.min - c && s <= a.max) {
			                var l = o.getAttribute("data-src-mobile");
			                o.onload = function () {
			                    this.className = this.className.replace(/(^|\s+)lazy-load(\s+|$)/, "$1lazy-loaded$2")
			                }, o.src = l && screen.width <= r.mobileScreenSize ? l : o.getAttribute("data-src"), o.removeAttribute("data-src"), o.removeAttribute("data-src-mobile"), r.cache.splice(i, 1)
			            } else i++
			        }
			        0 === r.cache.length && r.removeObservers()
			    },
			    init: function () {
			        document.querySelectorAll || (document.querySelectorAll = function (e) {
			            var t = document,
							n = t.documentElement.firstChild,
							r = t.createElement("STYLE");
			            return n.appendChild(r), t.__qsaels = [], r.styleSheet.cssText = e + "{x:expression(document.__qsaels.push(this))}", window.scrollBy(0, 0), t.__qsaels
			        }), t("load", function e() {
			            for (var t = document.querySelectorAll("img[data-src]"), a = 0; a < t.length; a++) {
			                var i = t[a];
			                r.cache.push(i)
			            }
			            r.addObservers(), r.loadVisibleImages(), n("load", e, !1)
			        })
			    }
			};
		    r.init()
		}()
    }
}, function (e, t, n) {
    var r = n(4),
		a = n(1);
    e.exports = function () {
        "use strict";

        function e() {
            if (s.$toggles = document.querySelectorAll("a[data-mobile-target]"), s.$toggles[0]) {
                t();
                for (var e = 0, n = s.$toggles.length; n > e; e++) s.$toggles[e].addEventListener(r, o)
            }
        }
        function t() {
            s.$layer = document.createElement("div"), s.$layer.id = "mobile-on-layer", s.$layer.addEventListener(r, i), document.body.appendChild(s.$layer)
        }
        function n() {
            var e = s.$last_click_btn.getAttribute("data-icon-active"),
				t = s.$last_click_btn.getAttribute("data-icon-original");
            document.body.classList.add("menu-on"), s.$last_target.classList.add("on"), e && t && (s.$last_click_btn.classList.remove(t), s.$last_click_btn.classList.add(e));
            var n = s.$last_click_btn.getAttribute("data-focus-target");
            if (n) {
                var r = document.querySelector(n);
                r && r.focus()
            }
        }
        function i() {
            var e = s.$last_click_btn.getAttribute("data-icon-active"),
				t = s.$last_click_btn.getAttribute("data-icon-original");
            document.body.classList.remove("menu-on"), s.$last_target.classList.remove("on"), e && t && (s.$last_click_btn.classList.remove(e), s.$last_click_btn.classList.add(t))
        }
        function o(e) {
            s.$last_target = document.querySelector(this.getAttribute("data-mobile-target")), s.$last_click_btn = this, s.$last_target.classList.contains("on") ? i() : n()
        }
        var s = {};
        a(e)
    }
}, function (e, t, n) {
    var r = n(4);
    e.exports = function () {
        function e() {
            var e = i.getAttribute("data-icon-active"),
				t = i.getAttribute("data-icon-original");
            o.classList.add("on"), e && t && (i.classList.remove(t), i.classList.add(e));
            var n = i.getAttribute("data-focus-target");
            if (n) {
                var r = document.querySelector(n);
                r && setTimeout(function () {
                    r.focus()
                }, 500)
            }
        }
        function t(e) {
            e && e.preventDefault();
            var t = i.getAttribute("data-icon-active"),
				n = i.getAttribute("data-icon-original");
            o.classList.remove("on"), t && n && (i.classList.remove(t), i.classList.add(n))
        }
        function n(n) {
            o = document.querySelector(this.getAttribute("data-toggle-target")), i = this, o.classList.contains("on") ? t() : e()
        }
        var a = document.querySelectorAll("a[data-toggle-target]");
        if (a[0]) for (var i, o, s = 0, c = a.length; c > s; s++) a[s].addEventListener(r, n)
    }
}, function (e, t, n) {
    var r = n(7),
		a = n(1);
    e.exports = function () {
        "use strict";

        function e() {
            o.$menu = document.querySelector(".nav-main"), o.$menu && (o.menu_height = o.$menu.offsetHeight, o.y = 0, o.fold = !1, i(window.pageYOffset), r(i))
        }
        function t() {
            o.fold || (o.$menu.classList.add("fold"), o.$menu.classList.remove("top"), o.fold = !0)
        }
        function n() {
            o.fold && (o.$menu.classList.remove("fold"), o.fold = !1)
        }
        function i(e) {
            e <= o.menu_height ? (n(), o.$menu.classList.add("top")) : o.y <= e ? t() : o.y - e < 100 && n(), o.y = e
        }
        var o = {};
        a(e)
    }
}, function (e, t) {
    e.exports = function () {
        try {
            top.location.hostname != window.location.hostname && (top.location.href = window.location.href)
        } catch (e) {
            top.location.href = window.location.href
        }
    }
}, function (e, t) {
    e.exports = function () {
        function e(e) {
            e && e.preventDefault(), setTimeout(function () {
                r.focus()
            }, 100)
        }
        var t = document.querySelector(".main-nav a.search");
        if (!t) return !1;
        var n = document.querySelector(t.getAttribute("data-toggle-target")),
			r = n.querySelector('input[type="search"]'),
			a = function () {
			    return "" === r.value.trim() ? (r.focus(), !1) : void 0
			};
        t.addEventListener(click_handle, e), n.onsubmit = a
    }
}, function (e, t, n) {
    var r = n(1),
		a = n(4);
    e.exports = function () {
        function e() {
            var e = document.querySelectorAll(".tab");
            if (e[0]) for (var n = 0, r = e.length; r > n; n++) t(e[n])
        }
        function t(e) {
            function t(e) {
                e.preventDefault();
                for (var t = this.getAttribute("data-i"), a = 0; i > a; a++) n[a].classList.remove("tab-active"), r[a].classList.remove("tab-active");
                if (this.classList.add("tab-active"), r[t]) {
                    r[t].classList.add("tab-active");
                    var o = r[t].querySelector("input");
                    o && o.focus()
                }
            }
            var n = e.querySelectorAll(".tab-title"),
				r = e.querySelectorAll(".tab-body"),
				i = n.length;
            if (n[0] && r[0]) for (var o = 0; i > o; o++) n[o].setAttribute("data-i", o), n[o].addEventListener(a, t)
        }
        r(e)
    }
}, function (e, t, n) {
    var r = n(1),
		a = n(4),
		i = n(6);
    e.exports = function () {
        function e() {
            u.$entry_content = document.querySelector(".entry-content"), u.$entry_content && t()[1] && (n(), c())
        }
        function t() {
            return u.$hs = u.$entry_content.querySelectorAll("h1,h2,h3,h4,h5,h6"), u.$hs
        }
        function n() {
            u.$ul = document.createElement("ol");
            for (var e = 0, t = u.$hs.length; t > e; e++) {
                var n = u.$hs[e].id || u.$hs[e].name || u.$hs[e].textContent || u.$hs[e].innerText,
					r = u.$hs[e].textContent || u.$hs[e].innerText,
					a = document.createElement("li");
                n = encodeURI(n), u.$hs[e].id = n, a.innerHTML = '<a href="#' + n + '">' + r + "</a>", u.$ul.appendChild(a), o(u.$hs[e])
            }
        }
        function o(e) {
            var t = document.createElement("a");
            t.href = "javascript:;", t.className = "entry-toc-up fa fa-angle-up", t.addEventListener(a, s), e.appendChild(t)
        }
        function s(e) {
            e.preventDefault(), scrollTo(0, i(u.$toc) - 70), history.pushState(null, null, "#entry-toc")
        }
        function c() {
            u.$toc = document.createElement("div"), u.$toc.id = "entry-toc", u.$toc.className = "expand", u.$toc.innerHTML = '<i class="fa fa-th-list"></i>', u.$title = u.$toc.querySelector("i"), u.$title.addEventListener(a, l), u.$toc.appendChild(u.$ul), u.$entry_content.insertBefore(u.$toc, u.$entry_content.firstChild)
        }
        function l(e) {
            e.preventDefault(), u.$toc.classList.contains("expand") ? (u.$toc.classList.remove("expand"), u.$toc.classList.add("fold")) : (u.$toc.classList.remove("fold"), u.$toc.classList.add("expand"))
        }
        r(e);
        var u = {}
    }
}, function (e, t, n) {
    var r = n(1);
    e.exports = function () {
        function e() {
            r(t)
        }
        function t() {
            var e = document.querySelectorAll(".hide-no-js"),
				t = document.querySelectorAll(".hide-on-js");
            if (e[0]) for (var n = 0, r = e.length; r > n; n++) e[n].style.display = "none";
            if (t[0]) for (var n = 0, r = t.length; r > n; n++) t[n].style.display = "none"
        }
        e()
    }
}, function (e, t, n) {
    n(41)(), n(32)(), n(38)(), n(37)(), n(36)(), n(31)(), n(40)(), n(43)(), n(35)(), n(39)(), n(29)(), n(42)(), n(18)(), n(19)(), n(17)(), n(24)(), n(21)(), n(20)(), n(22)(), n(13).init(), n(25)(), n(26)(), n(27)(), n(28)()
}, , , function (e, t, n) {
    var r = n(1),
		a = n(2),
		i = n(69),
		o = n(3),
		s = n(8),
		c = n(9),
		l = n(12);
    e.exports = function () {
        "use strict";

        function e() {
            p(), u(), n(), d()
        }
        function t() {
            return document.querySelectorAll(".clt-list").length
        }
        function n() {
            function e(e) {
                e && e.preventDefault();
                var r = t();
                return r < g.min_posts ? (o("error", g.lang.E02, 3), !1) : r > g.max_posts ? (o("error", g.lang.E03, 3), !1) : void n()
            }
            function n() {
                for (var e = document.querySelectorAll(".clt-list"), t = "", n = 0, a = e.length; a > n; n++) {
                    for (var s = e[n].querySelectorAll("[required]"), c = 0, l = s.length; l > c; c++) if ("" === s[c].value.trim()) return o("error", s[c].getAttribute("title"), 3), s[c].focus(), !1;
                    var u = e[n].getAttribute("data-id"),
						d = e[n].querySelectorAll("img"),
						p = d[d.length - 1].src;
                    t += i(g.tpl_preview, ["%hash%", "%title%", "%thumbnail%", "%content%"], [u, m("clt-list-post-title-" + u).value, p, m("clt-list-post-content-" + u).value])
                }
                r(t)
            }
            function r(e) {
                f.$preview_container.innerHTML = e
            }
            var a = m("clt-preview");
            return f.$preview_container = m("clt-preview-container"), a ? void a.addEventListener("click", e) : !1
        }
        function u() {
            function e() {
                var e = function (e) {
                    if (e && e.preventDefault(), t() >= g.max_posts) return o("error", g.lang.E03, 3), !1;
                    var i, s = Date.now(),
                        c = document.createElement("div");
                    c.innerHTML = n(s), i = c.firstChild, i.classList.add("delete"), a.$container.appendChild(i), r(i), setTimeout(function () {
                        i.classList.remove("delete")
                    }, 1)
                };
                a.$add.addEventListener("click", e)
            }
            function n(e) {
                return g.tpl_input.replace(/%placeholder%/g, e)
            }
            function r(e) {
                function n(n) {
                    var r = function (n) {
                        return n && n.preventDefault(), t() <= g.min_posts ? (o("error", g.lang.E02, 3), !1) : (e.classList.add("delete"), void setTimeout(function () {
                            e.parentNode.removeChild(e)
                        }, 500))
                    };
                    m("clt-list-del-" + n).addEventListener("click", r)
                }
                function r(e) {
                    function t() {
                        var t = m("clt-list-post-id-" + e),
							r = function (t) {
							    t.preventDefault();
							    var r = this.value;
							    return "" === r.trim() ? !1 : isNaN(r.trim()) === !0 ? (this.select(), o("error", g.lang.E04, 3), !1) : void (a(r) ? i(r, e) : n(r, e, this))
							};
                        t.addEventListener("change", r, !1), t.addEventListener("blur", r, !1)
                    }
                    function n(e, t, n) {
                        function a(a) {
                            a && "success" === a.status ? (r(e, a), i(e, t), o(a.status, a.msg, 3)) : a && "error" === a.status ? (r(e, a), n.select(), o(a.status, a.msg, 3)) : o("error", a)
                        }
                        o("loading", g.lang.M03);
                        var s = new XMLHttpRequest,
							l = {
							    type: "get-post",
							    "post-id": e,
							    "theme-nonce": window.DYNAMIC_REQUEST["theme-nonce"]
							};
                        s.open("GET", g.process_url + "&" + c(l)), s.send(), s.onload = function () {
                            if (s.status >= 200 && s.status < 400) {
                                var e;
                                try {
                                    e = JSON.parse(s.responseText)
                                } catch (t) {
                                    e = s.responseText
                                }
                                a(e)
                            } else o("error", g.lang.E01)
                        }, s.onerror = function () {
                            o("error", g.lang.E01)
                        }
                    }
                    function r(e, t) {
                        return f.posts && f.posts[e] ? !1 : (f.posts || (f.posts = {}), void (f.posts[e] = {
                            thumbnail: t.thumbnail,
                            title: t.title,
                            excerpt: t.excerpt
                        }))
                    }
                    function a(e, t) {
                        return f.posts && f.posts[e] ? t ? f.posts[e][t] : f.posts[e] : !1
                    }
                    function i(e, t) {
                        var n = m("clt-list-post-content-" + t),
							r = m("clt-list-thumbnail-" + t),
							a = m("clt-list-thumbnail-url-" + t);
                        f.posts[e].title && (m("clt-list-post-title-" + t).value = f.posts[e].title), f.posts[e].excerpt && "" === n.value.trim() && (n.value = f.posts[e].excerpt), f.posts[e].thumbnail && (r.src = f.posts[e].thumbnail.url, a.value = f.posts[e].thumbnail.url)
                    }
                    t()
                }
                if (!e) return !1;
                var a = e.getAttribute("data-id");
                n(a), r(a)
            }
            var a = {},
				i = document.querySelectorAll(".clt-list");
            if (!i[0]) return !1;
            a.$add = m("clt-add-post"), a.$container = m("clt-lists-container");
            for (var s = 0, l = i.length; l > s; s++) r(i[s]);
            e()
        }
        function d() {
            var e = {};
            if (e.$fm = m("fm-clt"), !e.$fm) return !1;
            var t = new l;
            t.$fm = e.$fm, t.process_url = g.process_url, t.error_tx = g.lang.E01, t.init()
        }
        function p() {
            function e(e) {
                e.stopPropagation(), e.preventDefault(), c.files = e.dataTransfer.files, n(c.files[0])
            }
            function t(e) {
                e.stopPropagation(), e.preventDefault(), c.files = e.target.files.length ? e.target.files : e.originalEvent.dataTransfer.files, n(c.files[0])
            }
            function n(e) {
                var t = new FileReader;
                t.onload = function (t) {
                    r(e)
                }, t.readAsDataURL(e)
            }
            function r(e) {
                a("loading", g.lang.M01);
                var t = new FormData,
					n = new XMLHttpRequest;
                t.append("type", "add-cover"), t.append("theme-nonce", window.DYNAMIC_REQUEST["theme-nonce"]), t.append("img", e), n.open("post", g.process_url), n.send(t), n.upload.onprogress = function (e) {
                    if (e.lengthComputable) {
                        var t = e.loaded / e.total * 100;
                        c.$progress_bar.style.width = t + "%"
                    }
                }, n.onload = function () {
                    if (n.status >= 200 && n.status < 400) {
                        var e;
                        try {
                            e = JSON.parse(n.responseText)
                        } catch (t) {
                            e = n.responseText
                        }
                        e && "success" === e.status ? (c.$cover.src = e.thumbnail.url, c.$thumbnail_id.value = e["attach-id"], o(e.status, e.msg, 3)) : e && "error" === e.status ? o(e.status, e.msg) : o("error", e)
                    } else o("error", g.lang.E01);
                    a("hide")
                }, n.onerror = function () {
                    o("error", g.lang.E01)
                }
            }
            function a(e, t) {
                return "hide" === e ? (c.$progress.style.display = "none", c.$file_area.style.display = "block", !1) : (c.$file_area.style.display = "none", c.$progress.style.display = "block", c.$progress_bar.style.width = "10%", void (c.$progress_tx.innerHTML = s(e, t)))
            }
            var i = m("clt-file"),
				c = {};
            return c.$cover = m("clt-cover"), c.$progress = m("clt-file-progress"), c.$tip = m("clt-file-tip"), c.$progress_bar = m("clt-file-progress-bar"), c.$progress_tx = m("clt-file-progress-tx"), c.$thumbnail_id = m("clt-thumbnail-id"), c.$file_area = m("clt-file-area"), i ? (i.addEventListener("change", t), i.addEventListener("drop", e), void i.addEventListener("dragover", t)) : !1
        }
        function m(e) {
            return document.getElementById(e)
        }
        if (window.THEME_CONFIG.theme_custom_collection) {
            var f = {},
				g = {
				    process_url: "",
				    tpl_input: "",
				    tpl_preview: "",
				    min_posts: 5,
				    max_posts: 10,
				    lang: {
				        M01: "Loading, please wait...",
				        M02: "A item has been deleted.",
				        M03: "Getting post data, please wait...",
				        M04: "Previewing, please wait...",
				        E01: "Sorry, server is busy now, can not respond your request, please try again later.",
				        E02: "Sorry, the minimum number of posts is %d.",
				        E03: "Sorry, the maximum number of posts is %d.",
				        E04: "Sorry, the post id must be number, please correct it."
				    }
				};
            g = a(g, window.THEME_CONFIG.theme_custom_collection), r(e)
        }
    }
}, ,
////////////////
function (e, t, n) {
    var r = n(1),
		a = n(2),
		i = n(3),
		o = n(12),
		s = n(74),
		c = n(5);
    e.exports = function () {
        "use strict";

        function e(e) {
            return document.getElementById(e)
        }
        function t() {
            r(n)
        }
        function n() {
            return N.$fm = e("fm-ctb"), N.$post_id = e("ctb-post-id"), N.$post_title = e("ctb-title"), N.$post_content = e("ctb-content"), N.$post_excerpt = e("ctb-excerpt"), //N.$file_area = e("ctb-file-area"), N.$file_btn = e("ctb-file-btn"), N.$file = e("ctb-file"), N.$files = e("ctb-files"), N.$file_progress_container = e("ctb-file-progress-container"), N.$file_progress = e("ctb-file-progress"), N.$file_completion_tip = e("ctb-file-completion"),
                N.$split_number = e("ctb-split-number"), N.$batch_insert = e("ctb-batch-insert-btn"), N.$fm ? (e("fm-ctb-loading").style.display = "none", N.$fm.style.display = "block", N.$post_title.focus(), g(), _(), q(), H(), k(), l(), u(), D.bind(), void A()) : !1
        }
        function l() {
            var e = function () {
                localStorage.setItem("ctb-split-number", this.value)
            };
            N.$split_number.addEventListener("change", e)
        }
        function u() {
            var e = parseInt(localStorage.getItem("ctb-split-number"));
            e > 0 && (N.$split_number.value = e)
        }
        function d(e) {
            var t = {
                full: {
                    url: e.full.url
                },
                large: {
                    url: e.large.url,
                    width: e.large.width,
                    height: e.large.height
                },
                thumbnail: {
                    url: e.thumbnail.url
                },
                "attach-id": e["attach-id"]
            };
            return t["attach-page-url"] = e["attach-page-url"], t
        }
        function p(e) {
            var t = tinymce.editors["ctb-content"];
            t && !t.isHidden() ? tinymce.editors["ctb-content"].setContent(e) : N.$post_content.value = e
        }
        function m() {
            var e = tinymce.editors["ctb-content"];
            return e && !e.isHidden() ? tinymce.editors["ctb-content"].getContent() : N.$post_content.value
        }
        function f(e) {
            var t = tinymce.editors["ctb-content"];
            t && !t.isHidden() ? t.execCommand("mceInsertContent", !1, e) : "undefined" != typeof QTags ? QTags.insertContent(e) : N.$post_content.value += e
        }
        function g() {
            if (!I.edit || !I.attachs) return !1;
            for (var e in I.attachs) M(I.attachs[e])
        }
        function _() {
            N.$file.addEventListener("change", $), N.$file.addEventListener("drop", v), N.$file.addEventListener("dragover", h)
        }
        function h(e) {
            e.stopPropagation(), e.preventDefault(), e.dataTransfer.dropEffect = "copy"
        }
        function v(e) {
            e.stopPropagation(), e.preventDefault(), N.files = e.dataTransfer.files, N.file_count = N.files.length, N.file = N.files[0], N.file_index = 0, b(N.files[0])
        }
        function $(e) {
            e.stopPropagation(), e.preventDefault(), N.files = e.target.files.length ? e.target.files : e.originalEvent.dataTransfer.files, N.file_count = N.files.length, N.file = N.files[0], N.file_index = 0, b(N.files[0]), N.$file_progress.style.width = "1px"
        }
        function b(e) {
            y(e)
        }
        function y(e) {
            w();
            var t = new FormData,
				n = new XMLHttpRequest;
            t.append("type", "upload"), t.append("theme-nonce", window.DYNAMIC_REQUEST["theme-nonce"]), t.append("img", e), n.open("post", I.process_url), n.onload = function () {
                n.status >= 200 && n.status < 400 ? x(n.responseText) : E(n.responseText), n = null
            }, n.upload.onprogress = function (e) {
                if (e.lengthComputable) {
                    var t = e.loaded * N.file_index / (e.total * N.file_count) * 100;
                    N.$file_progress.style.width = t + "%"
                }
            }, n.send(t)
        }
        function w() {
            var e = s(I.lang.M02, N.file_index + 1, N.file_count);
            T("loading", e)
        }
        function E(e) {
            e = e ? e : I.lang.E01, T("error", e)
        }
        function x(e) {
            try {
                e = JSON.parse(e)
            } catch (t) { }
            if (N.file_index++, e && "success" === e.status) if (M(e), N.file_count === N.file_index) {
                var n = s(I.lang.M04, N.file_index, N.file_count);
                T("success", n), N.$file.value = ""
            } else b(N.files[N.file_index]);
            else N.file_index > 0, N.file_count > N.file_index ? b(N.files[N.file_index]) : (N.is_uploading = !1, e && "error" === e.status ? E(e.msg) : (E(I.lang.E01), console.error(e)), N.$file.value = "")
        }
        function M(e) {
            var t = S(e);
            N.$files.style.display = "block", N.$files.appendChild(t), t.style.display = "block"
        }
        function S(t) {
            N.$post_title || (N.$post_title = e("ctb-title"));
            var n = document.createElement("div"),
				r = "" == N.$post_title ? I.lang.M10 : N.$post_title.value,
				a = '<a class="img-link" href="' + t.full.url + '" target="_blank" title="' + I.lang.M06 + '"><img src="' + t.thumbnail.url + '" alt="' + r + '" ></a><a href="javascript:;" class="btn btn-default btn-block ctb-insert-btn" id="ctb-insert-' + t["attach-id"] + '" data-size="large" data-attach-page-url="' + t["attach-page-url"] + '" data-width="' + t.large.width + '" data-height="' + t.large.height + '" data-large-url="' + t.large.url + '" ><i class="fa fa-plug"></i> ' + I.lang.M09 + '</a><input type="radio" name="ctb[thumbnail-id]" id="img-thumbnail-' + t["attach-id"] + '" value="' + t["attach-id"] + '" hidden class="img-thumbnail-checkbox" required ><label for="img-thumbnail-' + t["attach-id"] + '" class="ctb-set-cover-btn"><i class="fa fa-star"></i> ' + I.lang.M07 + '</label><input type="hidden" name="ctb[attach-ids][]" value="' + t["attach-id"] + '" >';
            n.id = "img-" + t["attach-id"], n.setAttribute("class", "thumbnail-tpl g-phone-1-2 g-tablet-1-3 g-desktop-1-4"), n.innerHTML = a, n.style.display = "none", (!I.thumbnail_id && !N.first_cover || t["attach-id"] == I.thumbnail_id) && (n.querySelector(".img-thumbnail-checkbox").checked = !0, N.first_cover = !0);
            for (var i = n.querySelectorAll(".ctb-insert-btn"), o = function () {
					f(L({
                attach_page_url: this.getAttribute("data-attach-page-url"),
                width: this.getAttribute("data-width"),
                height: this.getAttribute("data-height"),
                img_url: t[this.getAttribute("data-size")].url
            }))
            }, s = 0, c = i.length; c > s; s++) i[s].addEventListener("click", o, !1);
            return n
        }
        function L(e) {
            var t = "" == N.$post_title ? I.lang.M10 : N.$post_title.value;
            return '<p><a href="' + e.attach_page_url + '" title="' + t + '" target="_blank" ><img class="aligncenter" src="' + e.img_url + '" alt="' + t + '" width="' + e.width + '" height="' + e.height + '"></a></p>'
        }
        function T(e, t) {
            e && "loading" !== e ? (i(e, t), N.$file_progress_container.style.display = "none", N.$file_area.style.display = "block") : (i(e, t), N.$file_progress_container.style.display = "block", N.$file_area.style.display = "none")
        }
        function A() {
            N.$batch_insert.addEventListener("click", C)
        }
        function C() {
            var e = D.get_data_preview(),
				t = [],
				n = 0;
            if (!e) return !1;
            var r = Object.keys(e).length;
            for (var a in e) t.push(L({
                attach_page_url: e[a]["attach-page-url"],
                img_url: e[a].large.url,
                width: e[a].large.width,
                height: e[a].large.height
            })), N.$split_number.value > 0 && r - 1 > n && (n + 1) % N.$split_number.value == 0 && t.push(" <!--nextpage--> "), n++;
            t && f(t.join(""))
        }
        function k() {
            var e = new o;
            e.process_url = I.process_url, e.loading_tx = I.lang.M01, e.error_tx = I.lang.E01, e.$fm = N.$fm, e.before = function (e) {
                e.append("ctb[post-content]", m())
            }, e.done = function (e) {
                I.edit && N.$fm.querySelector(".submit").removeAttribute("disabled"), "success" === e.status && D.del()
            }, e.init()
        }
        //加载分类
        //function q() {
        //    function t(e) {
        //        var t = document.createElement("option");
        //        t.innerHTML = I.lang.M14, t.value = "", e.appendChild(t)
        //    }
        //    function n() {
        //        N.$parent_cat = document.createElement("select"), N.$parent_cat.name = "ctb[cats][]", N.$parent_cat.classList.add("ctb-cat"), N.$parent_cat.classList.add("form-control"), N.$parent_cat.required = !0, t(N.$parent_cat);
        //        for (var e in I.cats) if (!(I.cats[e].parent > 0)) {
        //            var n = document.createElement("option");
        //            n.value = I.cats[e].term_id, n.title = I.cats[e].description, n.innerHTML = I.cats[e].name, N.$parent_cat.appendChild(n)
        //        }
        //        N.$parent_cat.addEventListener("change", a), N.$cat_container.appendChild(N.$parent_cat)
        //    }
        //    function r(e) {
        //        var t = e.nextElementSibling;
        //        t && (t.parentNode.removeChild(t), r(e))
        //    }
        //    function a() {
        //        r(this);
        //        var e = this.value,
		//			n = N["$cat_" + e];
        //        if (e) {
        //            if (n) return void N.$cat_container.appendChild(n);
        //            for (var i in I.cats) if (I.cats[i].parent == e) {
        //                var o = document.createElement("option");
        //                o.value = I.cats[i].term_id, o.title = I.cats[i].description, o.innerHTML = I.cats[i].name, n || (n = document.createElement("select"), n.name = "ctb[cats][]", n.classList.add("ctb-cat"), n.classList.add("form-control"), t(n), n.addEventListener("change", a)), n.appendChild(o)
        //            }
        //            n && N.$cat_container.appendChild(n)
        //        }
        //    }
        //    return I.cats ? (N.$cat_container = e("ctb-cat-container"), void (N.$cat_container && n())) : !1
        //}
        function H() {
            for (var t = document.querySelectorAll(".theme_custom_post_source-source-radio"), n = document.querySelectorAll(".theme_custom_post_source-inputs"), r = function (t) {
					for (var r = t.getAttribute("target"), a = e(r), i = 0, o = n.length; o > i; i++) if (a && a.id === r && t.checked) {
						a.style.display = "block";
						var s = a.querySelector("input");
						"" === s.value.trim() && s.focus()
            } else n[i].style.display = "none"
            }, a = function () {
					r(this)
            }, i = 0, o = t.length; o > i; i++) r(t[i]), t[i].addEventListener("change", a)
        }
        if (window.THEME_CONFIG.theme_custom_contribution) {
            var N = {},
				I = {
				    fm_id: "fm-ctb",
				    file_area_id: "ctb-file-area",
				    file_btn_id: "ctb-file-btn",
				    file_id: "ctb-file",
				    file_tip_id: "ctb-file-tip",
				    files_id: "ctb-files",
				    edit: !1,
				    thumbnail_id: !1,
				    attachs: !1,
				    cats: !1,
				    default_size: "large",
				    process_url: "",
				    lang: {
				        M01: "Loading, please wait...",
				        M02: "Uploading {0}/{1}, please wait...",
				        M03: "Click to delete",
				        M04: "{0} files have been uploaded.",
				        M05: "Source",
				        M06: "Click to view source",
				        M07: "Set as cover.",
				        M08: "Optional: some description",
				        M09: "Insert",
				        M10: "Preview",
				        M11: "Large size",
				        M12: "Medium size",
				        M13: "Small size",
				        M14: "Please select a category",
				        E01: "Sorry, server is busy now, can not respond your request, please try again later."
				    }
				};
            I = a(I, window.THEME_CONFIG.theme_custom_contribution);
            var D = {
                config: {
                    save_interval: 30,
                    lang: {
                        M01: "You have a auto save version, do you want to restore? Auto save last time is {time}.",
                        M02: "Restore completed.",
                        M03: "The data has saved your browser."
                    }
                },
                timer: !1,
                bind: function () {
                    var t = this;
                    t.config.lang = I.auto_save.lang, this.save_key = "auto-save-" + N.$post_id.value, this.check_version(), this.timer = setInterval(function () {
                        t.save()
                    }, 1e3 * this.config.save_interval), N.$quick_save = e("ctb-quick-save"), N.$quick_save && N.$quick_save.addEventListener("click", function () {
                        "" === N.$post_title.value ? N.$post_title.focus() : (t.save(), i("success", t.config.lang.M03, 3))
                    })
                },
                get: function () {
                    var e = localStorage.getItem(this.save_key);
                    return e ? JSON.parse(e) : !1
                },
                check_version: function () {
                    var e = this.get();
                    if (!e || !e.can_restore) return !1;
                    var t = this.config.lang.M01.replace("{time}", e.time);
                    return confirm(t) ? (this.restore(), void i("success", this.config.lang.M02, 3)) : !1
                },
                get_data_preview: function () {
                    var e = document.querySelectorAll(".ctb-insert-btn");
                    if (!e[0]) return !1;
                    for (var t = document.querySelectorAll(".img-link"), n = document.querySelectorAll(" .img-link img"), r = document.querySelectorAll(".img-thumbnail-checkbox"), a = {}, i = 0, o = e.length; o > i; i++) a[r[i].value] = {
                        "attach-page-url": e[i].getAttribute("data-attach-page-url"),
                        full: {
                            url: t[i].href
                        },
                        large: {
                            url: e[i].getAttribute("data-large-url"),
                            width: e[i].getAttribute("data-width"),
                            height: e[i].getAttribute("data-height")
                        },
                        thumbnail: {
                            url: n[i].src
                        },
                        "attach-id": r[i].value
                    };
                    return a
                },
                del: function () {
                    localStorage.removeItem(this.save_key), clearInterval(this.timer)
                },
                save: function () {
                    var t = {
                        can_restore: !1
                    };
                    "" !== N.$post_title.value && (t.title = N.$post_title.value, t.can_restore = !0), "" !== N.$post_excerpt.value && (t.excerpt = N.$post_excerpt.value, t.can_restore = !0);
                    var n = m();
                    if ("" !== n && (t.content = n, t.can_restore = !0), document.querySelector(".theme_custom_storage-group") && (t.storage = {}, N.$storage_items = document.querySelectorAll(".theme_custom_storage-item"), N.$storage_items[0])) for (var r = 0, a = N.$storage_items.length; a > r; r++) {
                        t.storage[r] || (t.storage[r] = {});
                        var i = N.$storage_items[r].getAttribute("data-placeholder");
                        t.storage[r] = {
                            url: e("theme_custom_storage-" + i + "-url").value,
                            download_pwd: e("theme_custom_storage-" + i + "-download-pwd").value,
                            extract_pwd: e("theme_custom_storage-" + i + "-extract-pwd").value
                        };
                        var o = e("theme_custom_storage-" + i + "-name");
                        o && (t.storage[r].name = o.value)
                    }
                    var s = document.querySelectorAll(".ctb-preset-tag:checked");
                    if (s[0]) {
                        t.preset_tags = {};
                        for (var r = 0, a = s.length; a > r; r++) t.preset_tags[r] || (t.preset_tags[r] = {}), t.preset_tags[r] = s[r].id;
                        t.can_restore = !0
                    }
                    var c = document.querySelectorAll(".ctb-custom-tag");
                    if (c[0]) {
                        t.custom_tags = {};
                        for (var r = 0, a = c.length; a > r; r++) t.custom_tags[c[r].id] || (t.custom_tags[c[r].id] = {}), t.custom_tags[c[r].id] = c[r].value
                    }
                    var l = document.querySelector(".theme_custom_post_source-source-radio:checked");
                    l && (t.source = {
                        source: l.value,
                        reprint_url: e("theme_custom_post_source-reprint-url").value,
                        reprint_author: e("theme_custom_post_source-reprint-author").value
                    }), t.preview = this.get_data_preview(), t.preview && (t.can_restore = !0);
                    var u = document.querySelector(".img-thumbnail-checkbox:checked");
                    u && (t.cover_id = u.value, t.can_restore = !0);
                    var d = new Date;
                    t.time = d.getFullYear() + "-" + d.getMonth() + "-" + d.getDate() + " " + d.getHours() + ":" + d.getMinutes(), localStorage.setItem(this.save_key, JSON.stringify(t))
                },
                restore: function () {
                    var t = this.get();
                    if (!t || !t.can_restore) return !1;
                    if (t.title && (N.$post_title.value = t.title), t.excerpt && (N.$post_excerpt.value = t.excerpt), t.content && p(t.content), t.storage && document.querySelector(".theme_custom_storage-group")) {
                        var n = e("theme_custom_storage-container"),
							r = n.getAttribute("data-tpl");
                        n.innerHTML = "";
                        for (var a in t.storage) {
                            var i = c(r.replace(/\%placeholder\%/g, a)),
								o = i.querySelector("#theme_custom_storage-" + a + "-name");
                            o && (o.value = t.storage[a].name);
                            var s = i.querySelector("#theme_custom_storage-" + a + "-url");
                            s.value = t.storage[a].url;
                            var l = i.querySelector("#theme_custom_storage-" + a + "-download-pwd");
                            l.value = t.storage[a].download_pwd;
                            var u = i.querySelector("#theme_custom_storage-" + a + "-extract-pwd");
                            u.value = t.storage[a].extract_pwd, n.appendChild(i)
                        }
                    }
                    if (t.preset_tags) for (var a in t.preset_tags) {
                        var m = e(t.preset_tags[a]);
                        m && (m.checked = !0)
                    }
                    if (t.custom_tags) for (var a in t.custom_tags) {
                        var f = e(a);
                        f && (f.value = t.custom_tags[a])
                    }
                    if (t.source && t.source.source) {
                        var g = e("theme_custom_post_source-source-" + t.source.source),
							_ = e("theme_custom_post_source-reprint-url"),
							h = e("theme_custom_post_source-reprint-author");
                        _ && (_.value = t.source.reprint_url), _ && (h.value = t.source.reprint_author), g && (g.checked = !0)
                    }
                    if (t.preview) {
                        t.cover_id && (I.thumbnail_id = t.cover_id);
                        for (var a in t.preview) M(d(t.preview[a]))
                    }
                }
            };
            t()
        }
    }
}, , ,
///////////////
function (e, t, n) {
    function r() {
        if (f && (m.$my_medal_container = s("my-medal-container"), m.$my_medal_container)) {
            var e = l("my-medal-tpl", f);
            m.$my_medal_container.innerHTML = e;
            var t = document.querySelectorAll(".my-medal");
            if (t[0]) for (var n = 0, r = t.length; r > n; n++) t[n].addEventListener("click", i);
            if (m.$preset_medals = document.querySelectorAll(".preset-medal"), m.$preset_medals[0]) for (var n = 0, r = m.$preset_medals.length; r > n; n++) null === m.$preset_medals[n].getAttribute("disabled") && m.$preset_medals[n].addEventListener("click", a)
        }
    }
    function a(e) {
        e.preventDefault();
        var t = this;
        d("loading");
        var n = new XMLHttpRequest;
        n.open("post", f.process_url + "&type=add-medal&medal-id=" + this.getAttribute("data-id") + "&theme-nonce=" + window.DYNAMIC_REQUEST["theme-nonce"]), n.send(), n.onload = function () {
            if (n.status >= 200 && n.status < 400) {
                var e = n.responseText;
                try {
                    e = JSON.parse(n.responseText)
                } catch (r) { }
                if ("success" === e.status) {
                    var a = {};
                    a.my_medals = {}, e.medal.title = t.title, a.my_medals[e.medal.id] = e.medal;
                    var i = u(l("my-medal-tpl", a));
                    m.$my_medal_container.appendChild(i), e["consume-points"] > 0 && o(e["consume-points"]), d(e.status, e.msg, 3)
                } else "error" === e.status && d(e.status, e.msg, 3)
            } else d("loading", window.THEME_CONFIG.lang.E01)
        }, n.onerror = function () {
            d("loading", window.THEME_CONFIG.lang.E01)
        }
    }
    function i(e) {
        if (e.preventDefault(), confirm(f.lang.M01)) {
            var t = new XMLHttpRequest;
            t.open("post", f.process_url + "&type=delete-medal&medal-id=" + this.getAttribute("data-id") + "&theme-nonce=" + window.DYNAMIC_REQUEST["theme-nonce"]), t.send(), this.parentNode.removeChild(this)
        }
    }
    function o(e) {
        m.$points_number || (m.$points_number = s("points-number"));
        var t = parseInt(m.$points_number.innerHTML.replace(/,/g, "")) - parseInt(e);
        m.$points_number.innerHTML += "-" + e, setTimeout(function () {
            m.$points_number.innerHTML = p(t)
        }, 3e3)
    }
    function s(e) {
        return document.getElementById(e)
    }
    var c = n(1),
		l = n(77),
		u = n(5),
		d = n(3),
		p = n(73),
		m = {},
		f = window.THEME_CONFIG.theme_custom_medal;
    e.exports = function () {
        c(function () {
            r()
        })
    }
}, , , function (e, t, n) {
    var r = n(1),
		a = n(3),
		i = n(5),
		o = n(9),
		s = n(2);
    e.exports = function () {
        "use strict";

        function e() {
            r(function () {
                return t(), I.$tabs_container ? (g(), A(), void n()) : !1
            })
        }
        function t() {
            if (I.$tabs_container = H("pm-tab"), !I.$tabs_container) return !1;
            I.$dialogs_container = document.querySelector(".pm-dialog-container"), I.$tmp_dialogs = document.querySelectorAll(".pm-dialog"), I.$tmp_tabs = I.$tabs_container.querySelectorAll("a"), I.$dialog_new = H("pm-dialog-new"), I.$dialog_new_uid = H("pm-dialog-content-new"), I.$tabs = {}, I.$dialogs = {};
            var e = H("pm-loading-tip");
            e.parentNode.removeChild(e), H("pm-container").style.display = "block", I.tab_count = I.$tmp_tabs.length;
            for (var t = 0; t < I.tab_count; t++) {
                var n = I.$tmp_tabs[t].getAttribute("data-uid"),
					r = I.$tmp_tabs[t].querySelector(".close");
                I.$tabs[n] = I.$tmp_tabs[t], I.$dialogs[n] = I.$tmp_dialogs[t], "new" !== n && (N.userdata[n] = {
                    name: I.$tabs[n].querySelector(".author").innerHTML,
                    avatar: I.$tabs[n].querySelector("img").src,
                    url: I.$tabs[n].getAttribute("data-url")
                }), u(n), l(n), r && r.addEventListener("click", w), "new" !== n && I.$dialogs[n].addEventListener("submit", y)
            }
            for (var t = 0; t < I.tab_count; t++) {
                var n = I.$tmp_tabs[t].getAttribute("data-uid");
                n === N.uid && (m(n), p(n), I.$current_tab = I.$tabs[n])
            }
        }
        function n() {
            I.preset_uid = c(), I.preset_uid && (I.$tabs[I.preset_uid] ? f(I.preset_uid) : b(I.preset_uid))
        }
        function c() {
            return location.hash && parseInt(location.hash.replace("#", ""))
        }
        function l(e) {
            function t(t) {
                t.preventDefault(), t.stopPropagation(), m(e), p(e), C(e, "hide")
            }
            I.$tabs[e].addEventListener("click", t)
        }
        function u(e) {
            var t = I.$dialogs[e].querySelector(".pm-dialog-list");
            t && (t.scrollTop = t.scrollHeight)
        }
        function d(e) {
            return I.$current_tab.getAttribute("uid") === e
        }
        function p(e) {
            H("pm-dialog-content-" + e).focus()
        }
        function m(e) {
            N.uid = e;
            for (var t in I.$tabs) t != e ? (I.$tabs[t].classList.remove("active"), I.$dialogs[t].style.display = "none") : (I.$dialogs[e].style.display = "block", I.$tabs[e].classList.add("active"))
        }
        function f(e) {
            I.$tabs[e] || (I.$tabs[e] = H("pm-tab-" + e)), d(e) || m(e), p(e)
        }
        function g() {
            I.$dialog_new.addEventListener("submit", _)
        }
        function _() {
            var e = I.$dialog_new_uid.value;
            return I.$dialogs[e] ? (f(e), !1) : void b(e)
        }
        function h(e) {
            I.$tabs[e] = i(M(e)), I.$tabs_container.appendChild(I.$tabs[e]), I.$tmp_tabs = I.$tabs_container.querySelectorAll("a")
        }
        function v(e) {
            var t = i(S());
            t.addEventListener("click", w), I.$tabs[e].appendChild(t)
        }
        function $(e, t) {
            I.$dialogs[e] = i(L(e, t)), I.$dialogs_container.appendChild(I.$dialogs[e])
        }
        function b(e) {
            function t(t) {
                "success" === t.status ? (N.userdata[e] = {
                    avatar: t.avatar,
                    name: t.name,
                    url: t.url
                }, a(t.status, t.msg, 3), h(e), v(e), t.histories ? $(e, x(t.histories)) : $(e, T(e, N.lang.M05.replace("%name%", N.userdata[e].name))), I.$current_tab = I.$tabs[e], I.tab_count++, l(e), f(e), I.$dialogs[e].addEventListener("submit", y)) : "error" === t.status ? (a(t.status, t.msg, 3), I.$dialog_new_uid.select()) : (a("error", t), I.$dialog_new_uid.select())
            }
            a("loading", N.lang.M01);
            var n = new XMLHttpRequest;
            n.open("get", N.process_url + "&type=get-userdata&uid=" + e + "&theme-nonce=" + window.DYNAMIC_REQUEST["theme-nonce"]), n.send(), n.onload = function () {
                if (n.status >= 200 && n.status < 400) {
                    var e;
                    try {
                        e = JSON.parse(n.responseText)
                    } catch (r) {
                        e = n.responseText
                    }
                    t(e)
                } else fail()
            }, n.onerror = function () {
                a("error", N.lang.E01), I.$dialog_new_uid.select()
            }
        }
        function y(e) {
            function t(e) {
                e.status && "success" === e.status ? (a(e.status, e.msg, 3), k(N.uid)) : e.status && "error" === e.status ? a(e.status, e.msg, 5) : a("error", e), p(N.uid), r.removeAttribute("disabled")
            }
            function n() {
                a("error", N.lang.E01), p(N.uid), r.removeAttribute("disabled")
            }
            e.preventDefault();
            var r = I.$dialogs[N.uid].querySelector('button[type="submit"]');
            r.setAttribute("disabled", !0), a("loading", N.lang.M06);
            var i = new XMLHttpRequest,
				o = new FormData(this);
            o.append("type", "send"), o.append("theme-nonce", window.DYNAMIC_REQUEST["theme-nonce"]), o.append("uid", N.uid), i.open("post", N.process_url), i.send(o), i.onload = function () {
                if (i.status >= 200 && i.status < 400) {
                    var e;
                    try {
                        e = JSON.parse(i.responseText)
                    } catch (r) {
                        e = i.responseText
                    }
                    t(e)
                } else n()
            }, i.onerror = n
        }
        function w(e) {
            e.preventDefault(), e.stopPropagation();
            var t = this.parentNode,
				n = t.getAttribute("data-uid");
            N.uid == n && (f("new"), I.$current_tab = I.$tabs["new"]), I.tab_count--, t.parentNode.removeChild(t), I.$dialogs[n].parentNode.removeChild(I.$dialogs[n]), delete I.$tabs[n], delete I.$dialogs[n];
            var r = new XMLHttpRequest,
				a = new FormData;
            r.open("post", N.process_url), a.append("uid", n), a.append("theme-nonce", window.DYNAMIC_REQUEST["theme-nonce"]), a.append("type", "remove-dialog"), r.send(a)
        }
        function E(e, t) {
            var n = e;
            "me" === e && (n = N.uid);
            var r = I.$dialogs[n].querySelector(".pm-dialog-list");
            r.appendChild(i(T(e, t))), r.scrollTop = r.scrollHeight
        }
        function x(e) {
            var t = "";
            for (var n in e) t += T(e[n]);
            return t
        }
        function M(e) {
            return '<a id="pm-tab-' + e + '" href="javascript:;" data-uid="' + e + '" title="' + N.userdata[e].name + '"><img src="' + N.userdata[e].avatar + '" alt="avatar" class="avatar" width="24" height="24"> <span class="author">' + N.userdata[e].name + "</span></a>"
        }
        function S() {
            return '<b class="close">&times;</b>'
        }
        function L(e, t) {
            return t || (t = ""), '<form action="javascript:;" id="pm-dialog-' + e + '" class="pm-dialog"><div class="form-group pm-dialog-list">' + t + '</div><div class="form-group"><input type="text" id="pm-dialog-content-' + e + '" name="content" class="pm-dialog-conteng form-control" placeholder="' + N.lang.M02 + '" required title="' + N.lang.M03 + '"></div><div class="form-group"><button class="btn btn-success btn-block" type="submit"><i class="fa fa-check"></i>&nbsp;' + N.lang.M04 + "</button></div></form>"
        }
        function T(e, t) {
            var n = new Date,
				n = q(n, "yyyy/MM/dd hh:mm:ss"),
				r = "me" === e ? "me" : "sender";
            return '<section class="pm-dialog-' + r + '"><div class="pm-dialog-bg"><h4><span class="name"><a href="' + N.userdata[e].url + '" target="_blank">' + N.userdata[e].name + '</a></span> <span class="date"> ' + n + ' </span></h4><div class="media-content">' + t + "</div></div></section>"
        }
        function A() {
            function e(e) {
                if (e && "success" === e.status) {
                    var t = e.pm.pm_author,
						n = e.pm.pm_receiver;
                    I.timestamp = e.timestamp, t == N.my_uid && I.$dialogs[n] ? (E("me", e.pm.pm_content), k(n)) : (N.userdata[t] || (N.userdata[t] = {
                        name: e.pm.pm_author_name,
                        avatar: e.pm.pm_author_avatar,
                        url: e.pm.url
                    }), I.$dialogs[t] || (h(t), v(t), $(t), I.$dialogs[t].style.display = "none", C(t), I.tab_count++, l(t), I.$dialogs[t].addEventListener("submit", y)), E(t, e.pm.pm_content), N.uid != t && C(t)), A()
                } else e && "error" === e.status ? "timeout" === e.code && A() : setTimeout(function () {
                    A()
                }, 3e4)
            }
            function t() {
                setTimeout(function () {
                    A()
                }, 3e4)
            }
            var n = new XMLHttpRequest;
            I.timestamp || (I.timestamp = window.DYNAMIC_REQUEST.theme_custom_pm.timestamp), n.open("get", N.process_url + "&" + o({
                type: "comet",
                "theme-nonce": window.DYNAMIC_REQUEST["theme-nonce"],
                timestamp: I.timestamp
            })), n.send(), n.onload = function () {
                if (n.status >= 200 && n.status < 400) {
                    var r;
                    try {
                        r = JSON.parse(n.responseText)
                    } catch (a) {
                        r = n.responseText
                    }
                    e(r)
                } else t()
            }, n.onerror = t
        }
        function C(e, t) {
            "hide" === t ? I.$tabs[e].classList.remove("new-msg") : I.$tabs[e].classList.add("new-msg")
        }
        function k(e) {
            I.$inputs || (I.$inputs = {}), I.$inputs[e] || (I.$inputs[e] = H("pm-dialog-content-" + e)), I.$inputs[e].focus(), I.$inputs[e].value = ""
        }
        function q(e, t) {
            var n = {
                "M+": e.getMonth() + 1,
                "d+": e.getDate(),
                "h+": e.getHours(),
                "m+": e.getMinutes(),
                "s+": e.getSeconds(),
                "q+": Math.floor((e.getMonth() + 3) / 3),
                S: e.getMilliseconds()
            };
            /(y+)/.test(t) && (t = t.replace(RegExp.$1, (e.getFullYear() + "").substr(4 - RegExp.$1.length)));
            for (var r in n) new RegExp("(" + r + ")").test(t) && (t = t.replace(RegExp.$1, 1 == RegExp.$1.length ? n[r] : ("00" + n[r]).substr(("" + n[r]).length)));
            return t
        }
        function H(e) {
            return document.getElementById(e)
        }
        if (window.THEME_CONFIG.theme_custom_pm) {
            var N = {
                lang: {
                    M01: "Loading, please wait...",
                    M02: "Enter to send P.M.",
                    M03: "P.M. content",
                    M04: "Send P.M.",
                    M05: "Hello, I am %name%, welcome to chat with me what do you want.",
                    M06: "P.M. is sending, please wait...",
                    E01: "Sorry, server is busy now, can not respond your request, please try again later."
                },
                uid: "new",
                my_uid: "",
                userdata: {}
            },
				I = {};
            N = s(N, window.THEME_CONFIG.theme_custom_pm), e()
        }
    }
}, function (e, t, n) {
    var r = n(1),
		a = n(2),
		i = n(3);
    e.exports = function () {
        "use strict";

        function e() {
            r(function () {
                return t(), c.$fm_loading ? void n() : !1
            })
        }
        function t() {
            return c.$fm_loading = s("fm-bomb-loading"), c.$fm_loading ? (c.$fm = s("fm-bomb"), c.$attacker_points = s("bomb-attacker-points"), c.$target = s("bomb-target"), c.$target_name = s("bomb-target-name"), c.$target_points = s("bomb-target-points"), c.$target_avatar = s("bomb-target-avatar"), c.$points = document.querySelectorAll(".bomb-points"), c.$fm ? (c.$submit = c.$fm.querySelector(".submit"), c.$fm_loading.parentNode.removeChild(c.$fm_loading), c.$fm.style.display = "block", c.$fm.addEventListener("submit", o), c.$target.addEventListener("blur", u.bind, !0), void ("" === c.$target.value.trim() || isNaN(c.$target.value) || u.init(c.$target.value))) : !1) : !1
        }
        function n() {
            function e(e) {
                t(this)
            }
            function t(e) {
                for (var t, n = e.parentNode, r = 0, a = c.$points.length; a > r; r++) t = c.$points[r].parentNode, t.classList.contains("label-success") && t.classList.remove("label-success");
                n.classList.add("label-success"), c.points = parseInt(e.value)
            }
            for (var n = 0, r = c.$points.length; r > n; n++) c.$points[n].checked && t(c.$points[n]), c.$points[n].addEventListener("change", e)
        }
        function o(e) {
            e.preventDefault(), i("loading", l.lang.M02), c.$submit.setAttribute("disabled", !0);
            var t = new XMLHttpRequest,
				n = new FormData(c.$fm);
            n.append("theme-nonce", window.DYNAMIC_REQUEST["theme-nonce"]), t.open("POST", l.process_url), t.send(n), t.onload = function () {
                var e;
                try {
                    e = JSON.parse(t.responseText)
                } catch (n) {
                    e = t.responseText
                }
                if (e && "success" === e.status) {
                    var r = parseInt(c.$attacker_points.textContent.trim()),
						a = parseInt(c.$target_points.textContent.trim());
                    if (e.hit) i(e.status, e.msg), c.$attacker_points.innerHTML = r + '<span class="text-success">+' + c.points + "</span>", setTimeout(function () {
                        c.$attacker_points.innerHTML = r + c.points
                    }, 3e3), c.$target_points.innerHTML = a + '<span class="text-danger">-' + c.points + "</span>", setTimeout(function () {
                        c.$target_points.innerHTML = a - c.points
                    }, 3e3);
                    else {
                        i("warning", e.msg);
                        var o = Math.round(c.points / 2);
                        c.$attacker_points.innerHTML = r + '<span class="text-danger">-' + c.points + "</span>", setTimeout(function () {
                            c.$attacker_points.innerHTML = r - c.points
                        }, 3e3), c.$target_points.innerHTML = a + '<span class="text-success">+' + o + "</span>", setTimeout(function () {
                            c.$target_points.innerHTML = a + o
                        }, 3e3)
                    }
                } else e && "error" === e.status ? i(e.status, e.msg) : i("error", window.THEME_CONFIG.lang.E01);
                c.$submit.removeAttribute("disabled")
            }, t.onerror = function () {
                i("error", window.THEME_CONFIG.lang.E01), c.$submit.removeAttribute("disabled")
            }
        }
        function s(e) {
            return document.getElementById(e)
        }
        if (window.THEME_CONFIG.theme_custom_point_bomb) {
            var c = {},
				l = {
				    process_url: "",
				    lang: {
				        M01: "Target locking...",
				        M02: "Bombing, please wait..."
				    }
				};
            l = a(l, window.THEME_CONFIG.theme_custom_point_bomb);
            var u = {
                bind: function () {
                    return c.target_id = c.$target.value.trim(), "" === c.target_id || isNaN(c.target_id) ? !1 : void u.init(c.target_id)
                },
                init: function (e) {
                    this.get_target_form_cache(e) ? this.set_target(e) : this.get_target_form_server(e)
                },
                get_target_form_server: function (e) {
                    var t = this,
						n = new XMLHttpRequest;
                    i("loading", l.lang.M01), n.open("GET", l.process_url + "&type=get-target&target=" + e + "&theme-nonce=" + window.DYNAMIC_REQUEST["theme-nonce"]), n.send(), n.onload = function () {
                        if (n.status >= 200 && n.status < 400) {
                            var r;
                            try {
                                r = JSON.parse(n.responseText)
                            } catch (a) {
                                r = n.responseText
                            }
                            r && "success" === r.status ? (t.set_target_cache(e, {
                                name: r.name,
                                points: r.points,
                                avatar: r.avatar
                            }), t.set_target(e), i(r.status, r.msg), c.$submit.removeAttribute("disabled")) : r && "error" === r.status ? (c.$target.select(), i(r.status, r.msg)) : (i("error", r), c.$target.select())
                        } else i("error", window.THEME_CONFIG.lang.E01)
                    }, n.onerror = function () {
                        i("error", window.THEME_CONFIG.lang.E01)
                    }
                },
                set_target: function (e) {
                    c.$target_points.innerHTML = c.users[e].points, c.$target_name.innerHTML = c.users[e].name, c.$target_avatar.src = c.users[e].avatar
                },
                get_target_form_cache: function (e) {
                    return c.users && c.users[e]
                },
                set_target_cache: function (e, t) {
                    c.users || (c.users = []), c.users[e] = t
                }
            };
            e()
        }
    }
}, , function (e, t, n) {
    var r = n(1),
		a = n(3),
		i = n(2),
		o = n(12);
    e.exports = function () {
        "use strict";

        function e() {
            return c.$hgihlight_point = s("modify-count"), c.$hgihlight_point ? (c.$point_count = s("point-count"), c.$fm = s("fm-lottery"), c.$fm ? void t() : !1) : !1
        }
        function t() {
            function e(e) {
                "warning" === e.status && a(e.status, e.msg), "error" !== e.status && n(parseInt(e["new-points"]) - parseInt(c.$point_count.innerHTML))
            }
            function t() {
                c.$fm.querySelector(".submit").removeAttribute("disabled")
            }
            var r = new o;
            r.process_url = l.process_url, r.loading_tx = l.lang.M01, r.error_tx = window.THEME_CONFIG.lang.E01, r.$fm = c.$fm, r.done = e, r.always = t, r.init()
        }
        function n(e) {
            e > 0 ? (c.$hgihlight_point.classList.add("plus"), c.$hgihlight_point.innerHTML = "+" + e) : (c.$hgihlight_point.classList.add("mins"), c.$hgihlight_point.innerHTML = e), c.$hgihlight_point.style.display = "inline", setTimeout(function () {
                c.$hgihlight_point.classList.remove("plus"), c.$hgihlight_point.classList.remove("mins"), c.$hgihlight_point.style.display = "none", c.$point_count.innerHTML = parseInt(c.$point_count.innerHTML) + e
            }, 2e3)
        }
        function s(e) {
            return document.getElementById(e)
        }
        if (window.THEME_CONFIG.theme_point_lottery) {
            var c = {},
				l = {
				    process_url: "",
				    lang: {
				        M01: "Results coming soon..."
				    }
				};
            l = i(l, window.THEME_CONFIG.theme_point_lottery), r(e)
        }
    }
}, , , , , function (e, t, n) {
    var r = n(1),
		a = n(3),
		i = n(2);
    e.exports = function () {
        "use strict";

        function e(e) {
            return document.getElementById(e)
        }
        function t() {
            o.$fm = e("fm-change-avatar"), o.$fm && (o.$crop_container = e("cropper-container"), o.$avatar_preview = e("avatar-preview"), o.$crop_done_btn = e("cropper-done-btn"), o.$base64 = e("avatar-base64"), n())
        }
        function n() {
            function t(e) {
                e.stopPropagation(), e.preventDefault(), o.files = e.target.files.length ? e.target.files : e.originalEvent.dataTransfer.files, o.file = o.files[0], n(o.file)
            }
            function n(e) {
                var t = new FileReader;
                t.onload = function (n) {
                    return -1 === e.type.indexOf("image") ? (alert("Invalid file type."), !1) : (o.$crop_container.innerHTML = '<img src="' + t.result + '" alt="cropper">', o.$crop_container.style.display = "block", o.$crop_img = o.$crop_container.querySelector("img"), o.$avatar_preview.style.display = "block", o.cp = new Cropper(o.$crop_img, {
                        aspectRatio: 1,
                        preview: "#avatar-preview",
                        minCropBoxWidth: 150,
                        minCropBoxHeight: 150
                    }), void (o.$crop_done_btn.style.display = "block"))
                }, t.readAsDataURL(e)
            }
            //保存我的头像方法
            function r(e) {
                e.stopPropagation(), e.preventDefault();
                var t = new XMLHttpRequest,
					n = new FormData, //FormData对象，ajax传递值
					r = o.$fm.querySelector("[type=submit]");
                a("loading"), r.setAttribute("disabled", !0), n.append("b4", o.cp.getCroppedCanvas().toDataURL("image/jpeg", .75)), t.open("POST", s.process_url), t.send(n), t.onload = function () {
                    console.info(t.responseText);
                    if (t.status >= 200 && t.status < 400) {
                        var e = t.responseText;
                        try {
                            e = JSON.parse(t.responseText)
                        } catch (n) { }
                        e && "success" === e.status ? (a(e.status, e.msg), location.reload()) : e && "error" === e.status ? (a(e.status, e.msg), r.removeAttribute("disabled")) : (a("error", window.THEME_CONFIG.lang.E01), r.removeAttribute("disabled"))
                    } else a("error", window.THEME_CONFIG.lang.E01), r.removeAttribute("disabled")
                }, t.onerror = function () {
                    a("error", window.THEME_CONFIG.lang.E01), r.removeAttribute("disabled")
                }
            }
            o.$file = e("file"), o.$file.addEventListener("drop", t), o.$file.addEventListener("change", t), o.$fm.addEventListener("submit", r)
        }
        if (window.THEME_CONFIG.theme_custom_user_settings) {
            var o = {},
				s = {
				    process_url: ""
				};
            s = i(s, window.THEME_CONFIG.theme_custom_user_settings), r(t)
        }
    }
}, function (e, t, n) {
    var r = n(1),
		a = n(12),
		i = n(2);
    e.exports = function () {
        "use strict";

        function e() {
            r(t)
        }
        function t() {
            o.$fm = document.querySelector(".user-form"), o.$fm && n(o.$fm)
        }
        function n(e) {
            var t = new a;
            t.process_url = s.process_url, t.loading_tx = window.THEME_CONFIG.lang.M01, t.error_tx = window.THEME_CONFIG.lang.E01, t.$fm = e, t.init()
        }
        if (window.THEME_CONFIG.theme_custom_user_settings) {
            var o = {},
				s = {
				    process_url: ""
				};
            s = i(s, window.THEME_CONFIG.theme_custom_user_settings), e()
        }
    }
}, , , , , function (e, t) {
    e.exports = function (e, t, n) {
        for (var r, a = 0, i = t.length; i > a; a++) r = new RegExp(t[a], "g"), e = e.replace(r, n[a]);
        return e
    }
}, , , , function (e, t) {
    function n(e, t, n) {
        var r;
        return !isNaN(parseFloat(e)) && isFinite(e) ? (e = Number(e), e = ("undefined" != typeof t ? e.toFixed(t) : e).toString(), r = e.split("."), r[0] = r[0].toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1" + (n || ",")), r.join(".")) : NaN
    }
    e.exports = n
}, function (e, t) {
    e.exports = function () {
        var e = arguments;
        return arguments[0].replace(/\{(\d+)\}/g, function (t, n) {
            return e[parseInt(n) + 1]
        })
    }
}, , , function (e, t) {
    !
	function () {
	    function t(e) {
	        return e.replace(b, "").replace(y, ",").replace(w, "").replace(E, "").replace(x, "").split(M)
	    }
	    function n(e) {
	        return "'" + e.replace(/('|\\)/g, "\\$1").replace(/\r/g, "\\r").replace(/\n/g, "\\n") + "'"
	    }
	    function r(e, r) {
	        function a(e) {
	            return p += e.split(/\n/).length - 1, u && (e = e.replace(/\s+/g, " ").replace(/<!--[\w\W]*?-->/g, "")), e && (e = h[1] + n(e) + h[2] + "\n"), e
	        }
	        function i(e) {
	            var n = p;
	            if (l ? e = l(e, r) : o && (e = e.replace(/\n/g, function () {
					return p++, "$line=" + p + ";"
	            })), 0 === e.indexOf("=")) {
	                var a = d && !/^=[=#]/.test(e);
	                if (e = e.replace(/^=[=#]?|[\s;]*$/g, ""), a) {
	                    var i = e.replace(/\s*\([^\)]+\)/, "");
	                    f[i] || /^(include|print)$/.test(i) || (e = "$escape(" + e + ")")
	                } else e = "$string(" + e + ")";
	                e = h[1] + e + h[2]
	            }
	            return o && (e = "$line=" + n + ";" + e), v(t(e), function (e) {
	                if (e && !m[e]) {
	                    var t;
	                    t = "print" === e ? b : "include" === e ? y : f[e] ? "$utils." + e : g[e] ? "$helpers." + e : "$data." + e, w += e + "=" + t + ",", m[e] = !0
	                }
	            }), e + "\n"
	        }
	        var o = r.debug,
				s = r.openTag,
				c = r.closeTag,
				l = r.parser,
				u = r.compress,
				d = r.escape,
				p = 1,
				m = {
				    $data: 1,
				    $filename: 1,
				    $utils: 1,
				    $helpers: 1,
				    $out: 1,
				    $line: 1
				},
				_ = "".trim,
				h = _ ? ["$out='';", "$out+=", ";", "$out"] : ["$out=[];", "$out.push(", ");", "$out.join('')"],
				$ = _ ? "$out+=text;return $out;" : "$out.push(text);",
				b = "function(){var text=''.concat.apply('',arguments);" + $ + "}",
				y = "function(filename,data){data=data||$data;var text=$utils.$include(filename,data,$filename);" + $ + "}",
				w = "'use strict';var $utils=this,$helpers=$utils.$helpers," + (o ? "$line=0," : ""),
				E = h[0],
				x = "return new String(" + h[3] + ");";
	        v(e.split(s), function (e) {
	            e = e.split(c);
	            var t = e[0],
					n = e[1];
	            1 === e.length ? E += a(t) : (E += i(t), n && (E += a(n)))
	        });
	        var M = w + E + x;
	        o && (M = "try{" + M + "}catch(e){throw {filename:$filename,name:'Render Error',message:e.message,line:$line,source:" + n(e) + ".split(/\\n/)[$line-1].replace(/^\\s+/,'')};}");
	        try {
	            var S = new Function("$data", "$filename", M);
	            return S.prototype = f, S
	        } catch (L) {
	            throw L.temp = "function anonymous($data,$filename) {" + M + "}", L
	        }
	    }
	    var a = function (e, t) {
	        return "string" == typeof t ? h(t, {
	            filename: e
	        }) : s(e, t)
	    };
	    a.version = "3.0.0", a.config = function (e, t) {
	        i[e] = t
	    };
	    var i = a.defaults = {
	        openTag: "<%",
	        closeTag: "%>",
	        escape: !0,
	        cache: !0,
	        compress: !0,
	        parser: null
	    },
			o = a.cache = {};
	    a.render = function (e, t) {
	        return h(e, t)
	    };
	    var s = a.renderFile = function (e, t) {
	        var n = a.get(e) || _({
	            filename: e,
	            name: "Render Error",
	            message: "Template not found"
	        });
	        return t ? n(t) : n
	    };
	    a.get = function (e) {
	        var t;
	        if (o[e]) t = o[e];
	        else if ("object" == typeof document) {
	            var n = document.getElementById(e);
	            if (n) {
	                var r = (n.value || n.innerHTML).replace(/^\s*|\s*$/g, "");
	                t = h(r, {
	                    filename: e
	                })
	            }
	        }
	        return t
	    };
	    var c = function (e, t) {
	        return "string" != typeof e && (t = typeof e, "number" === t ? e += "" : e = "function" === t ? c(e.call(e)) : ""), e
	    },
			l = {
			    "<": "&#60;",
			    ">": "&#62;",
			    '"': "&#34;",
			    "'": "&#39;",
			    "&": "&#38;"
			},
			u = function (e) {
			    return l[e]
			},
			d = function (e) {
			    return c(e).replace(/&(?![\w#]+;)|[<>"']/g, u)
			},
			p = Array.isArray ||
		function (e) {
		    return "[object Array]" === {}.toString.call(e)
		}, m = function (e, t) {
		    var n, r;
		    if (p(e)) for (n = 0, r = e.length; r > n; n++) t.call(e, e[n], n, e);
		    else for (n in e) t.call(e, e[n], n)
		}, f = a.utils = {
		    $helpers: {},
		    $include: s,
		    $string: c,
		    $escape: d,
		    $each: m
		};
	    a.helper = function (e, t) {
	        g[e] = t
	    };
	    var g = a.helpers = f.$helpers;
	    a.onerror = function (e) {
	        var t = "Template Error\n\n";
	        for (var n in e) t += "<" + n + ">\n" + e[n] + "\n\n";
	        "object" == typeof console && console.error(t)
	    };
	    var _ = function (e) {
	        return a.onerror(e), function () {
	            return "{Template Error}"
	        }
	    },
			h = a.compile = function (e, t) {
			    function n(n) {
			        try {
			            return new c(n, s) + ""
			        } catch (r) {
			            return t.debug ? _(r)() : (t.debug = !0, h(e, t)(n))
			        }
			    }
			    t = t || {};
			    for (var a in i) void 0 === t[a] && (t[a] = i[a]);
			    var s = t.filename;
			    try {
			        var c = r(e, t)
			    } catch (l) {
			        return l.filename = s || "anonymous", l.name = "Syntax Error", _(l)
			    }
			    return n.prototype = c.prototype, n.toString = function () {
			        return c.toString()
			    }, s && t.cache && (o[s] = n), n
			},
			v = f.$each,
			$ = "break,case,catch,continue,debugger,default,delete,do,else,false,finally,for,function,if,in,instanceof,new,null,return,switch,this,throw,true,try,typeof,var,void,while,with,abstract,boolean,byte,char,class,const,double,enum,export,extends,final,float,goto,implements,import,int,interface,long,native,package,private,protected,public,short,static,super,synchronized,throws,transient,volatile,arguments,let,yield,undefined",
			b = /\/\*[\w\W]*?\*\/|\/\/[^\n]*\n|\/\/[^\n]*$|"(?:[^"\\]|\\[\w\W])*"|'(?:[^'\\]|\\[\w\W])*'|\s*\.\s*[$\w\.]+/g,
			y = /[^\w$]+/g,
			w = new RegExp(["\\b" + $.replace(/,/g, "\\b|\\b") + "\\b"].join("|"), "g"),
			E = /^\d[^,]*|,\d[^,]*/g,
			x = /^,+|,+$/g,
			M = /^$|,+/;
	    e.exports = a
	}()
}]);