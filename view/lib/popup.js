$(document).on("keydown", function(e) {
	switch (e.keyCode) {
		case 27: { // Esc
			requestClose();
			break;
		}
	}
});

// 종료 전 확인 필요한 경우 override
function requestClose() {
	window.close();
}

function confirmCancel() {
	confirm("작업을 취소하시겠습니까?"
	,	function() {
			window.close();
		}
	);
}

// 메인 폼에서 보내주는 메시지, 경우에 따라 override
function sendMsg(msg) {
	alert(msg);
}

// alert 재정의
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
