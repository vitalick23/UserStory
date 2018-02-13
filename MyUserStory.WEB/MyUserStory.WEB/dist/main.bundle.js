webpackJsonp(["main"],{

/***/ "../../../../../src/$$_lazy_route_resource lazy recursive":
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncatched exception popping up in devtools
	return Promise.resolve().then(function() {
		throw new Error("Cannot find module '" + req + "'.");
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "../../../../../src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "../../../../../src/app/Comment.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Comment; });
var Comment = /** @class */ (function () {
    function Comment(text, storyId) {
        this.text = text;
        this.storiesId = storyId;
    }
    return Comment;
}());



/***/ }),

/***/ "../../../../../src/app/MyComment.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Mycomment; });
var Mycomment = /** @class */ (function () {
    function Mycomment(name, message, storyId) {
        this.Name = name;
        this.Mes = message;
        this.StoryId = storyId;
    }
    return Mycomment;
}());



/***/ }),

/***/ "../../../../../src/app/Signalr.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SignalRService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var SignalRService = /** @class */ (function () {
    function SignalRService() {
        this.proxyName = 'comment';
        this.connectionEstablished = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["v" /* EventEmitter */]();
        this.messageReceived = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["v" /* EventEmitter */]();
        this.KeyPress = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["v" /* EventEmitter */]();
        this.connectionExists = false;
        // create hub connection
        this.connection = ($.hubConnection('http://localhost:51835'));
        // create new proxy as name already given in top
        this.proxy = this.connection.createHubProxy(this.proxyName);
        // register on server events
        this.registerOnServerEvents();
        // call the connecion start method to start the connection to send and receive events.
        this.startConnection();
    }
    // method to hit from client
    SignalRService.prototype.sendMessage = function (data) {
        // server side hub method using proxy.invoke with method name pass as param
        this.proxy.invoke('sendToAll', data);
    };
    SignalRService.prototype.sendPrint = function (data) {
        // server side hub method using proxy.invoke with method name pass as param
        this.proxy.invoke('whoPrint', data);
    };
    // check in the browser console for either signalr connected or not
    SignalRService.prototype.startConnection = function () {
        var _this = this;
        this.connection.start().done(function (data) {
            console.log('Now connected ' + data.transport.name + ', connection ID= ' + data.id);
            _this.connectionEstablished.emit(true);
            _this.connectionExists = true;
        }).fail(function (error) {
            console.log('Could not connect ' + error);
            _this.connectionEstablished.emit(false);
        });
    };
    SignalRService.prototype.registerOnServerEvents = function () {
        var _this = this;
        this.proxy.on('invokeAsync', function (data) {
            console.log('received in SignalRService: ' + JSON.stringify(data));
            _this.messageReceived.emit(data);
        });
        this.proxy.on('print', function (data) {
            console.log('Print: ' + JSON.stringify(data));
            _this.KeyPress.emit(data);
        });
    };
    SignalRService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [])
    ], SignalRService);
    return SignalRService;
}());



/***/ }),

/***/ "../../../../../src/app/Story.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Story; });
var Story = /** @class */ (function () {
    function Story(theme, text) {
        this.theme = theme;
        this.stories = text;
    }
    return Story;
}());



/***/ }),

/***/ "../../../../../src/app/app-routing.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppRoutingModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__stories_stories_component__ = __webpack_require__("../../../../../src/app/stories/stories.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__story_detali_story_detali_component__ = __webpack_require__("../../../../../src/app/story-detali/story-detali.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var routes = [
    { path: '', redirectTo: '/main', pathMatch: 'full' },
    { path: 'main', component: __WEBPACK_IMPORTED_MODULE_2__stories_stories_component__["a" /* StoriesComponent */] },
    { path: 'detail/:id', component: __WEBPACK_IMPORTED_MODULE_3__story_detali_story_detali_component__["a" /* StoryDetailComponent */] }
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["I" /* NgModule */])({
            exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* RouterModule */]],
            imports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* RouterModule */].forRoot(routes)]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());



/***/ }),

/***/ "../../../../../src/app/app.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/app.component.html":
/***/ (function(module, exports) {

module.exports = "<h1>{{title}}</h1>\n<router-outlet></router-outlet>\n\n\n"

/***/ }),

/***/ "../../../../../src/app/app.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var AppComponent = /** @class */ (function () {
    function AppComponent() {
        this.title = 'User Story';
    }
    AppComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-root',
            template: __webpack_require__("../../../../../src/app/app.component.html"),
            styles: [__webpack_require__("../../../../../src/app/app.component.css")]
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "../../../../../src/app/app.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_platform_browser__ = __webpack_require__("../../../platform-browser/esm5/platform-browser.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_common_http__ = __webpack_require__("../../../common/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__app_component__ = __webpack_require__("../../../../../src/app/app.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__stories_stories_component__ = __webpack_require__("../../../../../src/app/stories/stories.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__story_detali_story_detali_component__ = __webpack_require__("../../../../../src/app/story-detali/story-detali.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__story_service__ = __webpack_require__("../../../../../src/app/story.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__app_routing_module__ = __webpack_require__("../../../../../src/app/app-routing.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__comment_comment_component__ = __webpack_require__("../../../../../src/app/comment/comment.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__comment_service__ = __webpack_require__("../../../../../src/app/comment.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12__Signalr_service__ = __webpack_require__("../../../../../src/app/Signalr.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};













var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["I" /* NgModule */])({
            declarations: [
                __WEBPACK_IMPORTED_MODULE_4__app_component__["a" /* AppComponent */],
                __WEBPACK_IMPORTED_MODULE_5__stories_stories_component__["a" /* StoriesComponent */],
                __WEBPACK_IMPORTED_MODULE_6__story_detali_story_detali_component__["a" /* StoryDetailComponent */],
                __WEBPACK_IMPORTED_MODULE_10__comment_comment_component__["a" /* CommentComponent */],
            ],
            imports: [
                __WEBPACK_IMPORTED_MODULE_0__angular_platform_browser__["a" /* BrowserModule */],
                __WEBPACK_IMPORTED_MODULE_2__angular_forms__["a" /* FormsModule */],
                __WEBPACK_IMPORTED_MODULE_8__app_routing_module__["a" /* AppRoutingModule */],
                __WEBPACK_IMPORTED_MODULE_3__angular_common_http__["b" /* HttpClientModule */],
                __WEBPACK_IMPORTED_MODULE_9__angular_http__["b" /* HttpModule */],
                __WEBPACK_IMPORTED_MODULE_9__angular_http__["c" /* JsonpModule */]
            ],
            providers: [__WEBPACK_IMPORTED_MODULE_7__story_service__["a" /* StoryService */], __WEBPACK_IMPORTED_MODULE_11__comment_service__["a" /* CommentService */], __WEBPACK_IMPORTED_MODULE_12__Signalr_service__["a" /* SignalRService */]],
            bootstrap: [__WEBPACK_IMPORTED_MODULE_4__app_component__["a" /* AppComponent */]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "../../../../../src/app/comment.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return CommentService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common_http__ = __webpack_require__("../../../common/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var CommentService = /** @class */ (function () {
    function CommentService(http, _http) {
        this.http = http;
        this._http = _http;
        this.Url = 'http://localhost:51835/api/Comment';
    }
    CommentService.prototype.getComment = function (id) {
        var url = this.Url + "/" + id;
        var result = this._http.get(url);
        return result.map(function (responce) {
            return responce.json();
        });
    };
    CommentService.prototype.addComment = function (comment) {
        var result = this._http.post(this.Url, comment);
        return result.map(function (responce) {
            return responce.json();
        });
    };
    CommentService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_common_http__["a" /* HttpClient */], __WEBPACK_IMPORTED_MODULE_2__angular_http__["a" /* Http */]])
    ], CommentService);
    return CommentService;
}());



/***/ }),

/***/ "../../../../../src/app/comment/comment.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/comment/comment.component.html":
/***/ (function(module, exports) {

module.exports = "\n<h1>Comment</h1>\n<ul class=\"Comment\">\n  <li *ngFor=\"let c of comment\">\n      <h5>Text: {{ c.text }} Time: {{ c.timePublicate }}</h5>\n  </li>\n</ul>\n\n\n\n<div *ngIf=\"messagesPrint\">\n  <label>{{messagesPrint}}</label>\n  </div>\n<div>\n  <label>Name:\n    <input #name />\n  </label>\n  <label>HubComment:\n    <input #mess (keyup)=\"SendKeyPress($event, name.value)\"  />\n  </label>\n  <!-- (click) passes input value to add() and then clears the input -->\n  <button (click)=\"sendMessage(name.value,mess.value); mess.value='';\">\n    add\n  </button>\n\n\n\n"

/***/ }),

/***/ "../../../../../src/app/comment/comment.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return CommentComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__comment_service__ = __webpack_require__("../../../../../src/app/comment.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__Comment__ = __webpack_require__("../../../../../src/app/Comment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__Signalr_service__ = __webpack_require__("../../../../../src/app/Signalr.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__MyComment__ = __webpack_require__("../../../../../src/app/MyComment.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var CommentComponent = /** @class */ (function () {
    function CommentComponent(route, commentService, _signalRService, _ngZone) {
        this.route = route;
        this.commentService = commentService;
        this._signalRService = _signalRService;
        this._ngZone = _ngZone;
        this.messages = [];
        this.subscribeToEvents();
        this.canSendMessage = _signalRService.connectionExists;
        this._storyId = +this.route.snapshot.paramMap.get('id');
    }
    CommentComponent.prototype.subscribeToEvents = function () {
        var _this = this;
        this._signalRService.connectionEstablished.subscribe(function () {
            _this.canSendMessage = true;
        });
        this._signalRService.messageReceived.subscribe(function (message) {
            _this._ngZone.run(function () {
                if (message.StoryId === _this._storyId) {
                    _this.comment.push(new __WEBPACK_IMPORTED_MODULE_3__Comment__["a" /* Comment */](message.Mes, message.StoryId));
                    _this.messagesPrint = '';
                }
            });
        });
        this._signalRService.KeyPress.subscribe(function (data) {
            _this._ngZone.run(function () {
                var test = '';
                if (data.StoryId === _this._storyId) {
                    _this.messagesPrint = '';
                    if (data.Mes !== test) {
                        _this.messagesPrint = data.Name + ': ' + data.Mes;
                    }
                }
            });
        });
    };
    /*  private _hubConnection: HubConnection;
      public async: any;
      message = '';
      messages: string[] = [];
      public sendMessage(): void {
        const data = `Sent: ${this.message}`;
    
        this._hubConnection.invoke('sendToAll', 'nick' , data);
        this.messages.push(data);
      }*/
    CommentComponent.prototype.ngOnInit = function () {
        /* this._hubConnection = new HubConnection('http://localhost:51835/comment');
         console.log(this._hubConnection);
    
         this._hubConnection.start()
           .then(() => {
             console.log('Hub connection started');
           })
           .catch(err => {
             console.log('Error while establishing connection');
           });
         this._hubConnection.on('sendToAll', (nick: string, data: any) => {
           const received = `${nick} : ${data}`;
           this.messages.push(received);
         });*/
        this.initalize();
    };
    CommentComponent.prototype.initalize = function () {
        var _this = this;
        var id = +this.route.snapshot.paramMap.get('id');
        this.commentService.getComment(id)
            .subscribe(function (storyData) { return _this.comment = storyData; });
    };
    CommentComponent.prototype.SendKeyPress = function (event, name) {
        var mes = event.target.value;
        this._signalRService.sendPrint(new __WEBPACK_IMPORTED_MODULE_5__MyComment__["a" /* Mycomment */](name, mes, this._storyId));
    };
    CommentComponent.prototype.sendMessage = function (name, mess) {
        var _this = this;
        this._signalRService.sendMessage(new __WEBPACK_IMPORTED_MODULE_5__MyComment__["a" /* Mycomment */](name, mess, this._storyId));
        this.commentService.addComment(new __WEBPACK_IMPORTED_MODULE_3__Comment__["a" /* Comment */](mess, this._storyId))
            .subscribe(function (x) { return _this.comment.push(x); });
    };
    CommentComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-comment',
            template: __webpack_require__("../../../../../src/app/comment/comment.component.html"),
            styles: [__webpack_require__("../../../../../src/app/comment/comment.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__angular_router__["a" /* ActivatedRoute */],
            __WEBPACK_IMPORTED_MODULE_1__comment_service__["a" /* CommentService */],
            __WEBPACK_IMPORTED_MODULE_4__Signalr_service__["a" /* SignalRService */],
            __WEBPACK_IMPORTED_MODULE_0__angular_core__["N" /* NgZone */]])
    ], CommentComponent);
    return CommentComponent;
}());



/***/ }),

/***/ "../../../../../src/app/stories/stories.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/stories/stories.component.html":
/***/ (function(module, exports) {

module.exports = "<h2>Stories</h2>\n<ul class=\"Comment\">\n  <li *ngFor=\"let s of story\">\n    <a routerLink=\"/detail/{{s.id}}\">\n    <h2>{{ s.theme }}</h2>\n      </a>\n    <button class=\"delete\" title=\"delete hero\"\n            (click)=\"delete(s.id)\">x</button>\n  </li>\n</ul>\n\n<div>\n  <label>Story theme:\n    <input #storyTheme />\n  </label>\n  <p>\n  <label>Story Text:\n    <input #storyText />\n  </label>\n  </p>\n  <!-- (click) passes input value to add() and then clears the input -->\n  <button (click)=\"add(storyTheme.value, storyText.value); storyTheme.value=''; storyText.value = ''\">\n    add\n  </button>\n</div>\n\n\n"

/***/ }),

/***/ "../../../../../src/app/stories/stories.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return StoriesComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Story__ = __webpack_require__("../../../../../src/app/Story.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__story_service__ = __webpack_require__("../../../../../src/app/story.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var StoriesComponent = /** @class */ (function () {
    function StoriesComponent(route, storyService) {
        this.route = route;
        this.storyService = storyService;
    }
    StoriesComponent.prototype.delete = function (id) {
        var _this = this;
        this.storyService.deleteStory(id)
            .subscribe(function (x) { return _this.story.splice(_this.story.indexOf(_this.story.find(function (s) { return s.id === x; })), 1); });
    };
    StoriesComponent.prototype.add = function (theme, text) {
        var _this = this;
        theme = theme.trim();
        text = text.trim();
        if (!theme || !text) {
            return;
        }
        this.storyService.addStory(new __WEBPACK_IMPORTED_MODULE_1__Story__["a" /* Story */](theme, text))
            .subscribe(function (x) { return _this.story.push(x); });
    };
    StoriesComponent.prototype.ngOnInit = function () {
        this.initalize();
    };
    StoriesComponent.prototype.initalize = function () {
        var _this = this;
        this.storyService.getStory()
            .subscribe(function (storyData) { return _this.story = storyData; });
    };
    StoriesComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-stories',
            template: __webpack_require__("../../../../../src/app/stories/stories.component.html"),
            styles: [__webpack_require__("../../../../../src/app/stories/stories.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_3__angular_router__["a" /* ActivatedRoute */],
            __WEBPACK_IMPORTED_MODULE_2__story_service__["a" /* StoryService */]])
    ], StoriesComponent);
    return StoriesComponent;
}());



/***/ }),

/***/ "../../../../../src/app/story-detali/story-detali.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/story-detali/story-detali.component.html":
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"story\">\n\n  <h2>{{story.theme |  uppercase}}</h2>\n  <div><span>id:</span> {{story.id}}</div>\n  <div><span>Text: </span>{{story.stories}}</div>\n  <div><span>Time: </span>{{story.timePublicate}}</div>\n  <label>text:\n    <input [(ngModel)] = \"story.stories\" placeholder=\"name\">\n  </label>\n  <button (click)=\"goBack()\">go back</button>\n  <button (click)=\"save()\">save</button>\n</div>\n\n<app-comment></app-comment>\n"

/***/ }),

/***/ "../../../../../src/app/story-detali/story-detali.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return StoryDetailComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__story_service__ = __webpack_require__("../../../../../src/app/story.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var StoryDetailComponent = /** @class */ (function () {
    function StoryDetailComponent(route, storyService, location) {
        this.route = route;
        this.storyService = storyService;
        this.location = location;
    }
    StoryDetailComponent.prototype.getStory = function () {
        var _this = this;
        var id = +this.route.snapshot.paramMap.get('id');
        this.storyService.getStoryById(id).subscribe(function (x) { return _this.story = x; });
    };
    StoryDetailComponent.prototype.ngOnInit = function () {
        this.getStory();
    };
    StoryDetailComponent.prototype.goBack = function () {
        this.location.back();
    };
    StoryDetailComponent.prototype.save = function () {
        var _this = this;
        this.storyService.updateStory(this.story)
            .subscribe(function (x) { return _this.getStory(); });
    };
    StoryDetailComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-story-detali',
            template: __webpack_require__("../../../../../src/app/story-detali/story-detali.component.html"),
            styles: [__webpack_require__("../../../../../src/app/story-detali/story-detali.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* ActivatedRoute */],
            __WEBPACK_IMPORTED_MODULE_3__story_service__["a" /* StoryService */],
            __WEBPACK_IMPORTED_MODULE_2__angular_common__["f" /* Location */]])
    ], StoryDetailComponent);
    return StoryDetailComponent;
}());



/***/ }),

/***/ "../../../../../src/app/story.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return StoryService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common_http__ = __webpack_require__("../../../common/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var StoryService = /** @class */ (function () {
    function StoryService(http, _http) {
        this.http = http;
        this._http = _http;
        this.httpOptions = {
            headers: new __WEBPACK_IMPORTED_MODULE_1__angular_common_http__["c" /* HttpHeaders */]({ 'Content-Type': 'application/json' })
        };
        this.Url = 'http://localhost:51835/api/Story';
    }
    StoryService.prototype.getStory = function () {
        var result = this._http.get(this.Url);
        return result.map(function (responce) {
            return responce.json();
        });
    };
    StoryService.prototype.updateStory = function (story) {
        return this.http.put(this.Url, story, this.httpOptions);
    };
    StoryService.prototype.getStoryById = function (id) {
        var result = this._http.get(this.Url + '/' + id);
        return result.map(function (responce) {
            return responce.json();
        });
    };
    StoryService.prototype.deleteStory = function (id) {
        var url = this.Url + "/" + id;
        var result = this._http.delete(url);
        return result.map(function (responce) {
            return responce.json();
        });
    };
    /** POST: add a new hero to the server */
    StoryService.prototype.addStory = function (story) {
        var result = this._http.post(this.Url, story);
        return result.map(function (responce) {
            return responce.json();
        });
    };
    StoryService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_common_http__["a" /* HttpClient */], __WEBPACK_IMPORTED_MODULE_2__angular_http__["a" /* Http */]])
    ], StoryService);
    return StoryService;
}());



/***/ }),

/***/ "../../../../../src/environments/environment.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return environment; });
// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.
var environment = {
    production: false
};


/***/ }),

/***/ "../../../../../src/main.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__ = __webpack_require__("../../../platform-browser-dynamic/esm5/platform-browser-dynamic.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__app_app_module__ = __webpack_require__("../../../../../src/app/app.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");




if (__WEBPACK_IMPORTED_MODULE_3__environments_environment__["a" /* environment */].production) {
    Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["_13" /* enableProdMode */])();
}
Object(__WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__["a" /* platformBrowserDynamic */])().bootstrapModule(__WEBPACK_IMPORTED_MODULE_2__app_app_module__["a" /* AppModule */])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__("../../../../../src/main.ts");


/***/ })

},[0]);
//# sourceMappingURL=main.bundle.js.map