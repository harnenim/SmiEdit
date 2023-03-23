var alt   = false;
var ctrl  = false;
var shift = false;
var onMouseUp = null;
var onMouseMove = null;

var showDrag = false;
function setShowDrag(dragging) {
	showDrag = dragging;
}
function setDroppable() {
	var doc = $(document);
	doc.on("dragleave", function () {
		return false;
	});
	doc.on("dragover", function () {
		if (!showDrag) {
			binder.showDragging();
		}
		return false;
	});
}

function call(names, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9) {
	if (names.indexOf("refreshTime") < 0) {
		console.log(names);
	}
	var obj = window;
	names = names.split(".");
	for (var i = 0; i < names.length - 1; i++) {
		obj = obj[names[i]];
	}
	try {
		var name = names[names.length - 1];
		obj[name](p0, p1, p2, p3, p4, p5, p6, p7, p8, p9);
	} catch (e) {
	}
}

$(function () {
	var doc = $(document);
	var views = $(".view");
	views.css({"height": window.innerHeight});
	window.addEventListener("resize", function() {
		views.css({"height": window.innerHeight});
	});
	window.onkeydown = function() {
		switch(event.keyCode) {
			case 16: shift = true; break;
			case 17: ctrl  = true; break;
			case 18: alt   = true; break;
			case 116: return false; // F5 새로고침 방지
		}
	};
	window.onkeyup = function() {
		switch(event.keyCode) {
			case 16: shift = false; break;
			case 17: ctrl  = false; break;
			case 18: alt   = false; break;
		}
	};
	window.onmousewheel = function () {
		// 확대/축소 방지
		if (ctrl) {
			return false;
		}
	};
	window.addEventListener("mousemove", function() {
		if (onMouseMove) {
			onMouseMove(event);
		}
	});
	window.addEventListener("mouseup", function() {
		if (onMouseUp && typeof onMouseUp == "function") {
			onMouseUp(event);
			onMouseUp = true;
		}
	});

	// 우클릭 방지
	doc.on("contextmenu", function () {
		return false;
	});

	if (window.binder) binder.initAfterLoad();
});

//alert 재정의
_alert = alert;
_confirm = confirm;
alert = function(msg) {
	_alert(msg);
	// TODO
	//binder.alert(msg);
}
confirm = function(msg, yes, no) {
	var result = _confirm(msg);
	if (result) {
		if (yes) yes();
	} else {
		if (no) no();
	}
	
	// TODO
	afterConfirmYes = yes;
	afterConfirmNo  = no;
	//binder.confirm(msg);
	
	return result;
}
