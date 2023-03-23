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

// alert 재정의
_alert = alert;
_confirm = confirm;
alert = function(msg) {
	_alert(msg);
	// TODO
	//binder.alert(msg);
}
// confirm 재정의
var afterConfirmYes = null;
var afterConfirmNo  = null;
confirm = function(msg, yes, no) {
	var result = _confirm(msg);
	if (result) {
		if (yes) yes();
	} else {
		if (no) no();
	}
	
	// TODO
	/*
	afterConfirmYes = yes;
	afterConfirmNo  = no;
	binder.confirm(msg);
	*/
	
	return result;
}

var ctrl  = false;

$(function () {
	var doc = $(document);
	var views = $(".view");
	views.css({"height": window.innerHeight});
	window.addEventListener("resize", function() {
		views.css({"height": window.innerHeight});
	});
	window.onkeydown = function() {
		switch(event.keyCode) {
			case 17: ctrl = true; break;
			case 116: return false; // F5 새로고침 방지
		}
	};
	window.onkeyup = function() {
		switch(event.keyCode) {
			case 17: ctrl = false; break;
		}
	};
	window.onmousewheel = function () {
		// 확대/축소 방지
		if (ctrl) {
			return false;
		}
	};

	// 우클릭 방지
	doc.on("contextmenu", function () {
		return false;
	});

	if (window.binder) binder.initAfterLoad();
});
