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
