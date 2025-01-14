// from Johap.cs

window.Johap = {
	cho_ : "ᄀᄁᄂᄃᄄᄅᄆᄇᄈᄉᄊᄋᄌᄍᄎᄏᄐᄑᄒ"
,	jung : "ᅡᅢᅣᅤᅥᅦᅧᅨᅩᅪᅫᅬᅭᅮᅯᅰᅱᅲᅳᅴᅵ"
,	jong : "　ᆨᆩᆪᆫᆬᆭᆮᆯᆰᆱᆲᆳᆴᆵᆶᆷᆸᆹᆺᆻᆼᆽᆾᆿᇀᇁᇂ"
	
,	toJohap: function(origin) {
		let result = [];
		
		for (let i = 0; i < origin.length; i++) {
			let c = origin[i];

			if (c >= '가' && c <= '힣')
			{
				let cCho_ = Math.floor((c.charCodeAt() - 44032) / 588);
				let cJung = Math.floor((c.charCodeAt() - 44032) / 28) % 21;
				let cJong = ((c.charCodeAt() - 44032) % 28);

				if (cJong > 0) {
					result.push(Johap.cho_[cCho_]);
					result.push(Johap.jung[cJung]);
					result.push(Johap.jong[cJong]);
				} else {
					result.push(Johap.cho_[cCho_]);
					result.push(Johap.jung[cJung]);
				}
			} else {
				result.push(c);
			}
		}
		
		return result;
	}
}

setTimeout(function() { // 생성자 선언보다 나중에 돌아야 함
	Typing.Mode =
	{	typewriter: 0
	,	keyboard: 1
	,	toString: ["typewriter", "keyboard"]
	}
	Typing.Cursor =
	{	invisible: 0
	,	visible: 1
	,	hangeul: 2
	,	toString: ["invisible", "visible", "hangeul"]
	}
	Typing.toType = function(johap, mode, cursor) {
		if (cursor != null) {
			return Typing.toTypeWithCursor(johap/*origin*/, mode, cursor);
		}
		let result = null;
		switch (mode) {
			case Typing.Mode.typewriter:
				result = Typing.toTypeTypewriter(johap);
				break;
			case Typing.Mode.keyboard:
				result = Typing.toTypeKeyboard(johap);
				break;
		}
		return result;
	}
	Typing.toTypeTypewriter = function(johap) {
		let result = [];
		for (let i = 0; i < johap.length; i++) {
			let c = johap[i];
			switch (c) {
				case 'ᅪ': result.push('ᅩ'); result.push('ᅡ'); break;
				case 'ᅫ': result.push('ᅩ'); result.push('ᅢ'); break;
				case 'ᅬ': result.push('ᅩ'); result.push('ᅵ'); break;
				case 'ᅯ': result.push('ᅮ'); result.push('ᅥ'); break;
				case 'ᅰ': result.push('ᅮ'); result.push('ᅦ'); break;
				case 'ᅱ': result.push('ᅮ'); result.push('ᅵ'); break;
				case 'ᅴ': result.push('ᅳ'); result.push('ᅵ'); break;
				default: result.push(c); break;
			}
		}
		return result;
	}
	Typing.toTypeKeyboard = function(johap) {
		let result = [];
		for (let i = 0; i < johap.length; i++) {
			let c = johap[i];
			switch (c) {
				case 'ᄀ': result.push('ㄱ'); break;
				case 'ᄁ': result.push('ㄲ'); break;
				case 'ᄂ': result.push('ㄴ'); break;
				case 'ᄃ': result.push('ㄷ'); break;
				case 'ᄄ': result.push('ㄸ'); break;
				case 'ᄅ': result.push('ㄹ'); break;
				case 'ᄆ': result.push('ㅁ'); break;
				case 'ᄇ': result.push('ㅂ'); break;
				case 'ᄈ': result.push('ㅃ'); break;
				case 'ᄉ': result.push('ㅅ'); break;
				case 'ᄊ': result.push('ㅆ'); break;
				case 'ᄋ': result.push('ㅇ'); break;
				case 'ᄌ': result.push('ㅈ'); break;
				case 'ᄍ': result.push('ㅉ'); break;
				case 'ᄎ': result.push('ㅊ'); break;
				case 'ᄏ': result.push('ㅋ'); break;
				case 'ᄐ': result.push('ㅌ'); break;
				case 'ᄑ': result.push('ㅍ'); break;
				case 'ᄒ': result.push('ㅎ'); break;
				case 'ᅡ': result.push('ㅏ'); break;
				case 'ᅢ': result.push('ㅐ'); break;
				case 'ᅣ': result.push('ㅑ'); break;
				case 'ᅤ': result.push('ㅒ'); break;
				case 'ᅥ': result.push('ㅓ'); break;
				case 'ᅦ': result.push('ㅔ'); break;
				case 'ᅧ': result.push('ㅕ'); break;
				case 'ᅨ': result.push('ㅖ'); break;
				case 'ᅩ': result.push('ㅗ'); break;
				case 'ᅪ': result.push('ㅗ'); result.push('ㅏ'); break;
				case 'ᅫ': result.push('ㅗ'); result.push('ㅐ'); break;
				case 'ᅬ': result.push('ㅗ'); result.push('ㅣ'); break;
				case 'ᅭ': result.push('ㅛ'); break;
				case 'ᅮ': result.push('ㅜ'); break;
				case 'ᅯ': result.push('ㅜ'); result.push('ㅓ'); break;
				case 'ᅰ': result.push('ㅜ'); result.push('ㅔ'); break;
				case 'ᅱ': result.push('ㅜ'); result.push('ㅣ'); break;
				case 'ᅲ': result.push('ㅠ'); break;
				case 'ᅳ': result.push('ㅡ'); break;
				case 'ᅴ': result.push('ㅡ'); result.push('ㅣ'); break;
				case 'ᅵ': result.push('ㅣ'); break;
				case 'ᆨ': result.push('ㄱ'); break;
				case 'ᆩ': result.push('ㄲ'); break;
				case 'ᆪ': result.push('ㄱ'); result.push('ㅅ'); break;
				case 'ᆫ': result.push('ㄴ'); break;
				case 'ᆬ': result.push('ㄴ'); result.push('ㅈ'); break;
				case 'ᆭ': result.push('ㄴ'); result.push('ㅎ'); break;
				case 'ᆮ': result.push('ㄷ'); break;
				case 'ᆯ': result.push('ㄹ'); break;
				case 'ᆰ': result.push('ㄹ'); result.push('ㄱ'); break;
				case 'ᆱ': result.push('ㄹ'); result.push('ㅁ'); break;
				case 'ᆲ': result.push('ㄹ'); result.push('ㅂ'); break;
				case 'ᆳ': result.push('ㄹ'); result.push('ㅅ'); break;
				case 'ᆴ': result.push('ㄹ'); result.push('ㅌ'); break;
				case 'ᆵ': result.push('ㄹ'); result.push('ㅍ'); break;
				case 'ᆶ': result.push('ㄹ'); result.push('ㅎ'); break;
				case 'ᆷ': result.push('ㅁ'); break;
				case 'ᆸ': result.push('ㅂ'); break;
				case 'ᆹ': result.push('ㅂ'); result.push('ㅅ'); break;
				case 'ᆺ': result.push('ㅅ'); break;
				case 'ᆻ': result.push('ㅆ'); break;
				case 'ᆼ': result.push('ㅇ'); break;
				case 'ᆽ': result.push('ㅈ'); break;
				case 'ᆾ': result.push('ㅊ'); break;
				case 'ᆿ': result.push('ㅋ'); break;
				case 'ᇀ': result.push('ㅌ'); break;
				case 'ᇁ': result.push('ㅍ'); break;
				case 'ᇂ': result.push('ㅎ'); break;
				case 'ㄳ': result.push('ㄱ'); result.push('ㅅ'); break;
				case 'ㄵ': result.push('ㄴ'); result.push('ㅈ'); break;
				case 'ㄶ': result.push('ㄴ'); result.push('ㅎ'); break;
				case 'ㄺ': result.push('ㄹ'); result.push('ㄱ'); break;
				case 'ㄻ': result.push('ㄹ'); result.push('ㅁ'); break;
				case 'ㄼ': result.push('ㄹ'); result.push('ㅂ'); break;
				case 'ㄽ': result.push('ㄹ'); result.push('ㅅ'); break;
				case 'ㄿ': result.push('ㄹ'); result.push('ㅍ'); break;
				case 'ㄾ': result.push('ㄹ'); result.push('ㅌ'); break;
				case 'ㅀ': result.push('ㄹ'); result.push('ㅎ'); break;
				case 'ㅄ': result.push('ㅂ'); result.push('ㅅ'); break;
				default: result.push(c); break;
			}
		}
		return result;
	}
	
	Typing.toTypeWithCursor = function(origin, mode, cursor) {
		let result = [];
		let type = Johap.toJohap(origin);
		if (mode == Typing.Mode.keyboard) {
			type = Typing.toType(type, mode);
		}
		
		let typing = new Typing(mode, cursor);
		let t = typing.out();
		result.push(t);
		for (let i = 0; i < type.length; i++) {
			typing.type(type[i]);
			result.push(t = typing.out());
		}
		return result;
	}
	
	Typing.cho = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
	Typing.nCho = function(c) {
		switch (c) {
			case 'ㄱ': return 0;
			case 'ㄲ': return 1;
			case 'ㄴ': return 2;
			case 'ㄷ': return 3;
			case 'ㄸ': return 4;
			case 'ㄹ': return 5;
			case 'ㅁ': return 6;
			case 'ㅂ': return 7;
			case 'ㅃ': return 8;
			case 'ㅅ': return 9;
			case 'ㅆ': return 10;
			case 'ㅇ': return 11;
			case 'ㅈ': return 12;
			case 'ㅉ': return 13;
			case 'ㅊ': return 14;
			case 'ㅋ': return 15;
			case 'ㅌ': return 16;
			case 'ㅍ': return 17;
			case 'ㅎ': return 18;
		}
		return 0;
	}
	Typing.nJong = function(c) {
		switch (c) {
//			case '　' : return 0;
			case 'ㄱ': return 1;
			case 'ㄲ': return 2;
			case 'ㄳ': return 3;
			case 'ㄴ': return 4;
			case 'ㄵ': return 5;
			case 'ㄶ': return 6;
			case 'ㄷ': return 7;
			case 'ㄹ': return 8;
			case 'ㄺ': return 9;
			case 'ㄻ': return 10;
			case 'ㄼ': return 11;
			case 'ㄽ': return 12;
			case 'ㄾ': return 13;
			case 'ㄿ': return 14;
			case 'ㅀ': return 15;
			case 'ㅁ': return 16;
			case 'ㅂ': return 17;
			case 'ㅄ': return 18;
			case 'ㅅ': return 19;
			case 'ㅆ': return 20;
			case 'ㅇ': return 21;
			case 'ㅈ': return 22;
			case 'ㅊ': return 23;
			case 'ㅋ': return 24;
			case 'ㅌ': return 25;
			case 'ㅍ': return 26;
			case 'ㅎ': return 27;
		}
		return 0;
	}
});

window.Typing = function(mode, cursor) {
	this.typed = "";
	this.typing = " ";
	this.type = null;
	this.out = null;
	switch (mode) {
		case Typing.Mode.typewriter:
			this.type = this.typeTypewriter;
			break;
		case Typing.Mode.keyboard:
			this.type = this.typeKeyboard;
			break;
	}
	switch (cursor) {
		case Typing.Cursor.invisible:
			this.out = this.outputWithNoCursor;
			break;
		case Typing.Cursor.visible:
			this.out = this.outputWithCursor;
			break;
		case Typing.Cursor.hangeul:
			this.out = this.outputWithCursorOnlyHangeul;
			break;
	}
}
Typing.prototype.typeFunc = function() {}; // delegate
Typing.prototype.typeTypewriter = function(c) {
	if (c >= 'ᄀ' && c <= 'ᄒ') {
		// 초성
		if (this.typing != ' ') this.typed += this.typing;
		this.typing = c;
	} else if (c >= 'ᅡ' && c <= 'ᅵ') {
		// 중성
		if (this.typing >= 'ᄀ' && this.typing <= 'ᄒ') {
			this.typing = String.fromCharCode(44032/*'가'*/ + ((this.typing.charCodeAt() - 4352/*'ᄀ'*/) * 588) + ((c.charCodeAt() - 4449/*'ᅡ'*/) * 28));
			return;
		}

		// 이중중성
		if (this.typing >= '고' && this.typing <= '흐') {
			switch (((this.typing.charCodeAt() - '가'.charCodeAt()) / 28) % 21) {
				case 8: // ('고' - '가') / 28:
					if (c == 'ᅡ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 1); return; }
					if (c == 'ᅢ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 2); return; }
					if (c == 'ᅵ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 3); return; }
					break;
				case 13: // ('구' - '가') / 28:
					if (c == 'ᅥ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 1); return; }
					if (c == 'ᅦ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 2); return; }
					if (c == 'ᅵ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 3); return; }
					break;
				case 18: // ('그' - '가') / 28:
					if (c == 'ᅵ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 1); return; }
					break;
			}
		}

		// 이중모음
		switch (this.typing) {
			case 'ᅩ':
				if (c == 'ᅡ') { this.typing = 'ᅪ'; return; }
				if (c == 'ᅢ') { this.typing = 'ᅫ'; return; }
				if (c == 'ㅣ') { this.typing = 'ᅬ'; return; }
				break;
			case 'ᅮ':
				if (c == 'ᅥ') { this.typing = 'ᅯ'; return; }
				if (c == 'ᅦ') { this.typing = 'ᅰ'; return; }
				if (c == 'ᅵ') { this.typing = 'ᅱ'; return; }
				break;
			case 'ᅳ':
				if (c == 'ᅵ') { this.typing = 'ᅴ'; return; }
				break;
		}

		if (this.typing != ' ') {
			this.typed += this.typing;
		}
		this.typing = c;
	
	} else if (c >= 'ᆨ' && c <= 'ᇂ') {
		// 종성
		if (this.typing >= '가' && this.typing <= '히' && (this.typing.charCodeAt() % 28 == 16/*'가' % 28*/)) {
			this.typing = String.fromCharCode(this.typing.charCodeAt() + (c.charCodeAt() - 4520/*'ᆨ'*/ + 1));
		} else {
			this.typed += this.typing;
			this.typed += c;
			this.typing = ' ';
		}
	} else {
		if (this.typing != ' ') {
			this.typed += this.typing;
		}
		this.typed += c;
		this.typing = ' ';
	}
}
Typing.prototype.typeKeyboard = function(c) {
	if (c >= 'ㄱ' && c <= 'ㅎ') {
		if (this.typing >= '가' && this.typing <= '히') {
			if (this.typing.charCodeAt() % 28 == 16/*'가' % 28*/) {
				// 종성
				switch (c) {
					case 'ㄱ': this.typing = String.fromCharCode(this.typing.charCodeAt() +  1/*'각' - '가'*/); return;
					case 'ㄲ': this.typing = String.fromCharCode(this.typing.charCodeAt() +  2/*'갂' - '가'*/); return;
					case 'ㄴ': this.typing = String.fromCharCode(this.typing.charCodeAt() +  4/*'간' - '가'*/); return;
					case 'ㄷ': this.typing = String.fromCharCode(this.typing.charCodeAt() +  7/*'갇' - '가'*/); return;
					case 'ㄹ': this.typing = String.fromCharCode(this.typing.charCodeAt() +  8/*'갈' - '가'*/); return;
					case 'ㅁ': this.typing = String.fromCharCode(this.typing.charCodeAt() + 16/*'감' - '가'*/); return;
					case 'ㅂ': this.typing = String.fromCharCode(this.typing.charCodeAt() + 17/*'갑' - '가'*/); return;
					case 'ㅅ': this.typing = String.fromCharCode(this.typing.charCodeAt() + 19/*'갓' - '가'*/); return;
					case 'ㅆ': this.typing = String.fromCharCode(this.typing.charCodeAt() + 20/*'갔' - '가'*/); return;
					case 'ㅇ': this.typing = String.fromCharCode(this.typing.charCodeAt() + 21/*'강' - '가'*/); return;
					case 'ㅈ': this.typing = String.fromCharCode(this.typing.charCodeAt() + 22/*'갖' - '가'*/); return;
					case 'ㅊ': this.typing = String.fromCharCode(this.typing.charCodeAt() + 23/*'갗' - '가'*/); return;
					case 'ㅋ': this.typing = String.fromCharCode(this.typing.charCodeAt() + 24/*'갘' - '가'*/); return;
					case 'ㅌ': this.typing = String.fromCharCode(this.typing.charCodeAt() + 25/*'같' - '가'*/); return;
					case 'ㅍ': this.typing = String.fromCharCode(this.typing.charCodeAt() + 26/*'갚' - '가'*/); return;
					case 'ㅎ': this.typing = String.fromCharCode(this.typing.charCodeAt() + 27/*'갛' - '가'*/); return;
				}
			} else {
				// 이중종성
				switch ((this.typing.charCodeAt() - 44032/*'가'*/) % 28) {
					case 1: // '각' - '가':
						if (c == 'ㅅ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 2); return; } // ㄳ
						break;
					case 4: // '간' - '가':
						if (c == 'ㅈ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 1); return; } // ㄵ
						if (c == 'ㅎ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 2); return; } // ㄶ
						break;
					case 8: // '갈' - '가':
						if (c == 'ㄱ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 1); return; } // ㄺ
						if (c == 'ㅁ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 2); return; } // ㄻ
						if (c == 'ㅂ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 3); return; } // ㄼ
						if (c == 'ㅅ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 4); return; } // ㄽ
						if (c == 'ㅌ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 5); return; } // ㄾ
						if (c == 'ㅍ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 6); return; } // ㄿ
						if (c == 'ㅎ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 7); return; } // ㅀ
						break;
					case 17: // '갑' - '가':
						if (c == 'ㅅ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 1); return; } // ㅄ
						break;
				}
			}
		}

		// 이중자음
		switch (this.typing) {
			case 'ㄱ':
				if (c == 'ㅅ') { this.typing = 'ㄳ'; return; }
				break;
			case 'ㄴ':
				if (c == 'ㅈ') { this.typing = 'ㄵ'; return; }
				if (c == 'ㅎ') { this.typing = 'ㄶ'; return; }
				break;
			case 'ㄹ':
				if (c == 'ㄱ') { this.typing = 'ㄺ'; return; }
				if (c == 'ㅁ') { this.typing = 'ㄻ'; return; }
				if (c == 'ㅂ') { this.typing = 'ㄼ'; return; }
				if (c == 'ㅅ') { this.typing = 'ㄽ'; return; }
				if (c == 'ㅌ') { this.typing = 'ㄾ'; return; }
				if (c == 'ㅍ') { this.typing = 'ㄿ'; return; }
				if (c == 'ㅎ') { this.typing = 'ㅀ'; return; }
				break;
		}

		// 자음
		if (this.typing != ' ') {
			this.typed += this.typing;
		}
		this.typing = c;
		
	} else if (c >= 'ㅏ' && c <= 'ㅣ') {
		// 중성
		if (this.typing >= 'ㄱ' && this.typing <= 'ㅎ') {
			this.typing = String.fromCharCode(44032/*'가'*/ + (Typing.nCho(this.typing) * 588) + ((c.charCodeAt() - 12623/*'ㅏ'*/) * 28));
			return;
		}

		if (this.typing >= '가' && this.typing <= '힣') {
			// 이중중성
			switch (((this.typing.charCodeAt() - 44032/*'가'*/) / 28) % 21) {
				case 8: // ('고' - '가') / 28:
					if (c == 'ㅏ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 1); return; } // ㅘ
					if (c == 'ㅐ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 2); return; } // ㅙ
					if (c == 'ㅣ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 3); return; } // ㅚ
					break;
				case 13: // ('구' - '가') / 28:
					if (c == 'ㅓ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 1); return; } // ㅝ
					if (c == 'ㅔ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 2); return; } // ㅞ
					if (c == 'ㅣ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 3); return; } // ㅟ
					break;
				case 18: // ('그' - '가') / 28:
					if (c == 'ㅣ') { this.typing = String.fromCharCode(this.typing.charCodeAt() + 28 * 1); return; } // ㅢ
					break;
			}

			// 앞 글자 종성을 초성으로 가져오기
			switch ((this.typing.charCodeAt() - 44032/*'가'*/) % 28) {
				case 00/*가-가*/: break;
				case 01/*각-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 01); this.typing = String.fromCharCode(44032 + Typing.nCho('ㄱ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 02/*갂-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 02); this.typing = String.fromCharCode(44032 + Typing.nCho('ㄲ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 03/*갃-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 02); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅅ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 04/*간-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 04); this.typing = String.fromCharCode(44032 + Typing.nCho('ㄴ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 05/*갅-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 01); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅈ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 06/*갆-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 02); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅎ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 07/*갇-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 07); this.typing = String.fromCharCode(44032 + Typing.nCho('ㄷ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 08/*갈-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 08); this.typing = String.fromCharCode(44032 + Typing.nCho('ㄹ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 09/*갉-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 01); this.typing = String.fromCharCode(44032 + Typing.nCho('ㄱ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 10/*갊-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 02); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅁ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 11/*갋-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 03); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅂ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 12/*갌-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 04); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅅ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 13/*갍-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 05); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅌ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 14/*갎-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 06); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅍ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 15/*갏-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 07); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅎ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 16/*감-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 16); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅁ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 17/*갑-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 17); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅂ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 18/*값-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 01); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅅ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 19/*갓-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 19); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅅ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 20/*갔-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 20); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅆ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 21/*강-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 21); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅇ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 22/*갖-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 22); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅈ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 23/*갗-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 23); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅊ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 24/*갘-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 24); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅋ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 25/*같-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 25); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅌ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 26/*갚-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 26); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅍ') * 588 + (c.charCodeAt() - 12623) * 28); return;
				case 27/*갛-가*/: this.typed += String.fromCharCode(this.typing.charCodeAt() - 27); this.typing = String.fromCharCode(44032 + Typing.nCho('ㅎ') * 588 + (c.charCodeAt() - 12623) * 28); return;
			}
		}

		// 이중모음
		switch (this.typing) {
			case 'ㅗ':
				if (c == 'ㅏ') { this.typing = 'ㅘ'; return; }
				if (c == 'ㅐ') { this.typing = 'ㅙ'; return; }
				if (c == 'ㅣ') { this.typing = 'ㅚ'; return; }
				break;
			case 'ㅜ':
				if (c == 'ㅓ') { this.typing = 'ㅝ'; return; }
				if (c == 'ㅔ') { this.typing = 'ㅞ'; return; }
				if (c == 'ㅣ') { this.typing = 'ㅟ'; return; }
				break;
			case 'ㅡ':
				if (c == 'ㅣ') { this.typing = 'ㅢ'; return; }
				break;
		}

		// 모음
		if (this.typing != ' ') {
			this.typed += this.typing;
		}
		this.typing = c;
		
	} else {
		if (this.typing != ' ') this.typed += this.typing;
		this.typed += c;
		this.typing = ' ';
	}
}

Typing.prototype.out = function() {}; // delegate
Typing.prototype.outputWithNoCursor = function() {
	if (this.typing == ' ') {
		return this.typed;
	}
	return this.typed + this.typing;
}
Typing.prototype.outputWithCursor = function() {
	return this.typed + "<U>" + this.typing + "</U>";
}
Typing.prototype.outputWithCursorOnlyHangeul = function() {
	if ((this.typing >= 'ㄱ' && this.typing <= 'ㅎ')
	 || (this.typing >= 'ㅏ' && this.typing <= 'ㅣ')
	 || (this.typing >= '가' && this.typing <= '힣')
	 || (this.typing >= 'ᄀ' && this.typing <= 'ᄒ')
	 || (this.typing >= 'ᅡ' && this.typing <= 'ᅵ')
	 || (this.typing >= 'ᆨ' && this.typing <= 'ᇂ')) {
		return this.outputWithCursor();
	} else {
		return this.outputWithNoCursor();
	}
}










// from SubtitleObject.cs


window.Subtitle = {
	SyncType:
	{	comment: -1
	,	normal: 0
	,	frame: 1
	,	inner: 2
	}
};
Subtitle.SyncAttr = function(start, end, startType, endType, text) {
	this.start = start ? start : 0;
	this.end   = end   ? end   : 35999999;
	this.startType = startType ? startType : Subtitle.SyncType.normal;
	this.endType   = endType   ? endType   : Subtitle.SyncType.normal;
	this.text = text ? text : null;
}
/*
	public interface ISubtitleObject<SObj>
	{
		string ToTxt();
		string ColorToAttr(string soColor);
		string ColorFromAttr(string attrColor);

		List<Attr> ToAttr();
		SObj FromAttr(List<Attr> attrs);

		SyncAttr ToSync();
		SObj FromSync(SyncAttr sync);
	}
	public interface ISubtitleFile<SObj, FObj>
	{
		string ToTxt();
		FObj FromTxt(string txt);

		List<SyncAttr> ToSync();
		FObj FromSync(List<SyncAttr> sync);
	}
*/
Subtitle.Width =
{	DEFAULT_FONT: { fontFamily: "맑은 고딕", fontSize: 72 }
/*
	public static Font DEFAULT_FONT = new Font("맑은 고딕", 72.0F);
	public static Image FAKE_IMAGE = new Bitmap(1, 1);
*/
,	getWidth: function(input, font) {
		if (typeof input == "string") {
			if (!font) font = this.DEFAULT_FONT;
			if (!this.div) {
				$("body").append(this.div = $("<div>").css({
						position: "absolute"
					,	top: -1000
					,	whiteSpace: "pre"
				}));
			}
			this.div.css(font).text(input);
			return this.div.width();
		} else {
			let width = 0;
			for (let i = 0; i < input.length; i++) {
				let attr = input[i];
				width += attr.getWidth();
			}
			return width;
		}
	}
,	getWidths: function(lines) {
		let widths = [];
		for (let i = 0; i < lines.length; i++) {
			widths.push(this.getWidth(line));
		}
		return widths;
	}
,	getAppend: function(targetWidth, isBoth, font) {
		if (!font) font = this.DEFAULT_FONT;
	
		if (isBoth) targetWidth /= 2;
		
		let whiteSpace = "";
		let lastWidth = 0;
		let thisWidth = 0;
		if (thisWidth >= targetWidth) {
			return whiteSpace;
		}
		
		while (thisWidth < targetWidth) {
			lastWidth = thisWidth;
			whiteSpace += "　";
			thisWidth = Subtitle.Width.getWidth(whiteSpace);
		}
		
		thisWidth = lastWidth;
		whiteSpace = whiteSpace.substring(0, whiteSpace.length - 1);
		
		while (thisWidth < targetWidth) {
			lastWidth = thisWidth;
			whiteSpace += " ";
			thisWidth = Subtitle.Width.getWidth(whiteSpace);
		}
		
		if (thisWidth - targetWidth > targetWidth - lastWidth) {
			whiteSpace = whiteSpace.substring(0, whiteSpace.length - 1);
		}
		
		return isBoth ? whiteSpace : Subtitle.Width.appendToRight(whiteSpace);
	}
,	getAppendToTarget: function(width, targetWidth) {
		return this.getAppend(targetWidth - width, false, this.DEFAULT_FONT);
	}
,	appendToRight: function(append) {
		let index = append.indexOf(' ');
		if (index > 0) {
			return append.substring(index) + append.substring(0, index);
		}
		return append;
	}
}

Subtitle.Attr = function(old) {
	if (old) {
		this.text = "";
		this.b    = old.b;
		this.i    = old.i;
		this.u    = old.u;
		this.fs   = old.fs;
		this.fn   = old.fn;
		this.fc   = old.fc;
		this.fade = old.fade;
		this.shake = old.shake;
		this.typing = old.typing;
	} else {
		this.text = "";
		this.b    = false; // Bold
		this.i    = false; // Italic
		this.u    = false; // Underline
		this.fs   = 0;	// FontSize
		this.fn   = ""; // FontName
		this.fc   = ""; // Fontcolor
		this.fade = 0;
		this.shake = null;
		this.typing = null;
	}
}
Subtitle.Attr.TypingAttr = function(mode, start, end) {
	this.cursor = Typing.Cursor.visible;
	this.mode   = mode;
	this.start  = start ? start : 0;
	this.end	= end   ? end   : 0;
}
Subtitle.Attr.prototype.getWidth = function() {
	let css = Subtitle.Width.DEFAULT_FONT;
	if (this.fs) css.fontSize   = this.fs;
	if (this.fn) css.fontFamily = this.fn;
	return Subtitle.Width.getWidth(this.text, css);
}
Subtitle.Attr.getWidths = function(attrs) {
	let widths = [];
	let width = 0;
	let index = 0;
	for (let i = 0; i < attrs.length; i++) {
		let attr = attrs[i];
		if ((index = attr.text.indexOf('\n')) >= 0) {
			let sAttr = new Subtitle.Attr(attr);
			
			sAttr.text = attr.text.substring(0, index);
			width += sAttr.getWidth();
			widths.push(width);
			
			sAttr.text = attr.text.substring(index + 1);
			width += sAttr.getWidth();
			
		} else {
			width += attr.getWidth();
		}
	}
	widths.push(width);
	return widths;
}

Subtitle.Attr.fromSubtitle = function(subtitle) {
	return subtitle.toAttr();
}
Subtitle.Attr.linesFromSubtitle = function(subtitle) {
	let attrs = Subtitle.Attr.fromSubtitle(subtitle);
	
	let line = [];
	let lines = [line];
	let index = 0;
	for (let i = 0; i < attrs.length; i++) {
		let attr = attrs[i];
		
		if ((index = attr.text.indexOf('\n')) >= 0) {
			let sAttr = new Subtitle.Attr(attr);
			sAttr.text = attr.text.substring(0, index);
			line.push(sAttr);
			lines.push(line = []);

			sAttr = new Subtitle.Attr(attr);
			sAttr.text = attr.text.substring(index + 1);
			line.push(sAttr);
			
		} else {
			line.push(attr);
		}
	}
	return lines;
}
Subtitle.Attr.toSubtitle = function(attrs, subtitle) {
	subtitle.fromAttr(attrs);
}

Subtitle.Attr.prototype.toHtml = function() {
	if (this.text == null || this.text.length == 0) {
		return "";
	}
	
	let css = "";
	if (this.b) css += "font-weight: bold;";
	if (this.i) css += "font-style: italic;";
	if (this.u) css += "font-decoration: underline;";
	if (this.fs > 0) css += "font-size: " + fs + "px; line-height: " + (11 + 4 * this.fs) + "px;";
	if (this.fn != null && this.fn.length > 0) css += "font-family: '" + this.fn + "';";
	if (this.fc != null && this.fc.length > 0) css += "color: #" + this.fc + ";";
	return "<span" + (css.length > 0 ? " style=\"" + css + "\"" : "") + ">"
		+ $("<a>").text(text).html().split(" ").join("&nbsp;").split("\n").join("​<br>​")
		+ "</span>";
}
Subtitle.Attr.toHtml = function(attrs) {
	let result = "";
	for (let i = 0; i < attrs.length; i++) {
		result += attrs[i].toHtml();
	}
	return result;
}





// SubtitleObjectAss.cs

Subtitle.Ass = function(start, end, style, text) {
	this.start = start;
	this.end   = end;
	this.style = style;
	this.text  = text;
}
Subtitle.Ass.cols = [ "Layer", "Start", "End", "Style", "Name", "MarginL", "MarginR", "MarginV", "Effect", "Text" ];

Subtitle.Ass.int2Time = function(time) {
	time = Math.round(time);
	let h = Math.floor(time / 360000);
	let m = Math.floor(time / 6000) % 60;
	let s = Math.floor(time / 100) % 60;
	let ds= Math.floor(time % 100);
	return h + ":" + intPadding(m) + ":" + intPadding(s) + "." + intPadding(ds);
}
function intPadding(value, length = 2) {
	value = "" + value;
	while (value.length < length) {
		value = "0" + value;
	}
	return value;
}
Subtitle.Ass.time2Int = function(time) {
	let vs = time.split(':');
	return (Number(vs[0]) * 360000) + (Number(vs[1]) * 6000) + (Number(vs[2].split(".").join("")));
}

Subtitle.Ass.prototype.toTxt = function() {
	return "Dialogue: 0," + Subtitle.Ass.int2Time(this.start) + "," + Subtitle.Ass.int2Time(this.end) + "," + this.style + ",,0,0,0,," + this.text;
}
Subtitle.Ass.ss2txt = function(asss) {
	let result = "";
	for (let i = 0; i < asss.length; i++) {
		result += asss[i].toTxt() + "\r\n";
	}
	return result;
}

Subtitle.Ass.sColorFromAttr = function(soColor) {
	return soColor.length == 6 ? "&H" + soColor.substring(4, 6) + soColor.substring(2, 4) + soColor.substring(0, 2) + "&" : "";
}
Subtitle.Ass.colorToAttr = function(soColor) {
	return "" + soColor.substring(6, 8) + soColor.substring(4, 6) + soColor.substring(2, 4);
}
Subtitle.Ass.colorFromAttr = function(attrColor) {
	return this.sColorFromAttr(attrColor);
}

Subtitle.Ass.prototype.toAttr = function() {
	let result = [];

	let index = 0;
	let pos = 0;
	let last = new Subtitle.Attr();
	result.push(last);

	while ((pos = this.text.indexOf('{', index)) >= 0) {
		last.text += this.text.substring(index, pos).split("\\N").join("\n");

		let endPos = text.indexOf('}', pos);
		let attrString = this.text.substring(pos + 1, endPos);

		let mode = -1;
		let tagStart = 0, tagEnd = 0;
		let tag = null;
		for (pos = 0; pos < attrString.length; pos++) {
			switch (mode) {
				case -1: { // 태그 시작 전
					while (pos < attrString.length && attrString[pos] != '\\') pos++;
					mode = 0;
					tagStart = pos + 1;
					pos--;
					break;
				}

				case 0: { // 태그
					for (tagEnd = tagStart; tagEnd < attrString.length; tagEnd++) {
						if (attrString[tagEnd] == '\\') {
							break;
						} else if (attrString[tagEnd] == '(') {
							mode++;
							pos = tagEnd + 1;
							break;
						}
					}
					if (mode > 0) break;
					if (tagStart == tagEnd) break;

					tag = attrString.substring(tagStart, tagEnd);

					if (tag[0] == "c" || tag.substring(0,2) == "1c") {
						if (last.text.length > 0) {
							result.push((last = new Subtitle.Attr(last)));
						}
						if (tag[0] == "c") {
							tag = "1" + tag;
						}
						if (tag.length >= 11 && tag[2] == '&' && tag[3] == 'H' && tag[10] == '&') {
							last.fc = Subtitle.Ass.colorToAttr(tag.substring(2, 11));
						} else {
							last.fc = "";
						}
					} else if (tag.substring(0,2) == "fn") {
						if (last.text.length > 0) {
							result.push((last = new Subtitle.Attr(last)));
						}
						last.fn = (tag.length > 2) ? tag.substring(2) : "";
						
					} else if (tag[0] == "b") {
						if (last.text.length > 0) {
							result.push((last = new Subtitle.Attr(last)));
						}
						last.b = (tag.length >= 2 && tag[1] == '1');
						
					} else if (tag[0] == "u") {
						if (last.text.length > 0) {
							result.push((last = new Subtitle.Attr(last)));
						}
						last.u = (tag.length >= 2 && tag[1] == '1');
						
					} else if (tag[0] == "i") {
						if (last.text.length > 0) {
							result.push((last = new Subtitle.Attr(last)));
						}
						last.i = (tag.length >= 2 && tag[1] == '1');
					}

					mode = 0;
					pos = tagEnd;
					tagStart = tagEnd + 1;
					break;
				}

				default: { // 괄호
					for (; pos < attrString.length; pos++) {
						if (attrString[pos] == ')') {
							mode--;
							break;
						}
					}
					break;
				}
			}
		}

		index = endPos + 1;
	}
	last.text += text.substring(index).split("\n").join("\\n");

	return result;
}
Subtitle.Ass.prototype.fromAttr = function(attrs) {
	let text = "";
	
	let last = new Subtitle.Attr();
	for (let i = 0; i < attrs.length; i++) {
		let attr = attrs[i];
		
		if (!last.b && attr.b) text += "{\\b1}";
		else if (last.b && !attr.b) text += "{\\b}";

		if (!last.i && attr.i) text += "{\\i1}";
		else if (last.i && !attr.i) text += "{\\i}";

		if (!last.u && attr.u) text += "{\\u1}";
		else if (last.u && !attr.u) text += "{\\u}";

		if (last.fn != attr.fn) text += "{\\fn" + attr.fn + "}";

		if (last.fc != attr.fc) text += "{\\c" + Subtitle.Ass.colorFromAttr(attr.fc) + "}";
		
		if (attr.furigana) {
			text += "[" + attr.text + "|" + attr.furigana.text.split("]").join("\\]") + "]";
		} else {
			text += attr.text;
		}
		last = attr;
	}
	
	let lines = text.split("\n");
	for (let i = 0; i < lines.length; i++) {
		let line = lines[i];
		let rubyList = [];
		
		let pos = 0;
		let rStart = 0;
		do {
			rStart = line.indexOf("[", pos);
			if (rStart < 0) {
				break;
			}
			let fStart = line.indexOf("|", rStart);
			if (fStart < 0) {
				pos = rStart + 1;
				continue;
			}
			let rEnd = fStart;
			do {
				rEnd = line.indexOf("]", rEnd);
				if (rEnd < 0) {
					break;
				}
				if (line[rEnd - 1] != "\\") {
					break;
				}
				rEnd++;
			} while (rEnd > 0);
			if (rEnd < 0) {
				pos = fStart + 1;
				continue;
			}
			pos = rEnd + 1;
			rubyList.push([rStart, fStart, rEnd]);
		} while (true);

		if (rubyList.length) {
			let newLine = "";
			for (let j = 0; j < rubyList.length; j++) {
				newLine += "{\\fscy50\\bord0\\1a&HFF&}";
				let pos = 0;
				for (let k = 0; k < j; k++) {
					newLine += line.substring(pos, rubyList[k][0]);
					newLine += line.substring(rubyList[k][0] + 1, rubyList[k][1]);
					pos = rubyList[k][2] + 1;
				}
				newLine += line.substring(pos, rubyList[j][0]);
				newLine += "{\\1a\\bord\\fscx50}" + line.substring(rubyList[j][1] + 1, rubyList[j][2]).split("\\]").join("]") + "{\\fscx\\bord0\\1a&HFF&}";
				pos = rubyList[j][2] + 1;
				for (let k = j + 1; k < rubyList.length; k++) {
					newLine += line.substring(pos, rubyList[k][0]);
					newLine += line.substring(rubyList[k][0] + 1, rubyList[k][1]);
					pos = rubyList[k][2] + 1;
				}
				newLine += line.substring(pos);
				newLine += "{\\1a\\bord\\fscy}\\N";
			}
			{
				let pos = 0;
				for (let k = 0; k < rubyList.length; k++) {
					newLine += line.substring(pos, rubyList[k][0]);
					newLine += line.substring(rubyList[k][0] + 1, rubyList[k][1]);
					pos = rubyList[k][2] + 1;
				}
				newLine += line.substring(pos);
			}
			lines[i] = newLine;
		}
	}

	this.text = lines.join("\\N").split("}{").join("");
	return this;
}

Subtitle.Ass.prototype.toSync = function() {
	return new Subtitle.SyncAttr(
			start * 10
		,	end * 10
		,	(this.style.StartsWith("［") ? Subtitle.SyncType.frame : Subtitle.SyncType.normal)
		,	(this.style.EndsWith  ("］") ? Subtitle.SyncType.frame : Subtitle.SyncType.normal)
		,	this.toAttr()
	);
}
Subtitle.Ass.prototype.fromSync = function(sync) {
	this.start = sync.start / 10;
	this.end   = sync.end   / 10;
	this.style = 
		( (sync.startType == Subtitle.SyncType.normal && sync.endType == Subtitle.SyncType.normal)
			? "Default"
			: ( (sync.startType == Subtitle.SyncType.frame ? "［" : "（")
			  + (sync.endType   == Subtitle.SyncType.frame ? "］" : "）")
			)
		);
	this.fromAttr(sync.text);
	return this;
}

Subtitle.AssFile = function(txt) {
	this.header = "";
	this.body = [];
	if (txt) {
		this.fromTxt(txt);
	}
}
Subtitle.AssFile.prototype.toTxt = function() {
	let result = this.header.split("\r\n").join("\n");
	for (let i = 0; i < this.body.length; i++) {
		result += this.body[i].toTxt() + "\n";
	}
	return result;
}
Subtitle.AssFile.prototype.fromTxt = function(txt) {
	this.header = "";
	this.body = [];
	
	let lines = txt.split("\r\n").join("\n").split('\n');
	
	let header = [];
	let canBeHeader = true;
	for (let i = 0; i < lines.length; i++) {
		let l = lines[i];
		
		if (l.substring(0,9) == ("Dialogue:")) {
			canBeHeader = false;
			let line = l.trim().split(',');
			let ass = new Subtitle.Ass(
				Subtitle.Ass.time2Int(line[1])
			,	Subtitle.Ass.time2Int(line[2])
			,	line[3]
			,	line[9]
			);
			for (let j = 10; j < line.length; j++) {
				ass.text += "," + line[j];
			}
			this.body.push(ass);
			
		} else if (canBeHeader) {
			if (l.substring(0,7) == ("Format:")) {
				//canBeHeader = false;
				let line = l.trim().split(',');
				Subtitle.Ass.cols = [];
				for (let j = 0; j < line.length; j++) {
					Subtitle.Ass.cols.push(line[j].trim());
				}
				
			}
			header.push(l);
		}
	}
	this.header = header.join("\n") + "\n";

	return this;
}
Subtitle.AssFile.prototype.toSync = function() {
	let result = [];
	for (let i = 0; i < this.body.length; i++) {
		result.push(this.body[i].toSync());
	}
	return result;
}

Subtitle.AssFile.prototype.fromSync = function(syncs) {
	this.body = [];
	for (let i = 0; i < syncs.length; i++) {
		this.body.push(new Subtitle.Ass().fromSync(syncs[i]));
	}
	return this;
}





// SubtitleObjectSmi.cs

Subtitle.Smi = function(start, syncType, text) {
	this.start = start ? Math.round(start) : 0;
	this.syncType = syncType ? syncType : Subtitle.SyncType.normal;
	this.text = text ? text : "";
}

Subtitle.Smi.prototype.toTxt = function() {
	if (this.syncType == Subtitle.SyncType.comment) { // Normalize 시에만 존재
		return "<!--" + this.text + "-->";
	}
	return "<Sync Start=" + this.start + "><P Class=KRCC" + (this.syncType == Subtitle.SyncType.inner ? "\t" : (this.syncType == Subtitle.SyncType.frame ? " " : "")) + ">\n" + this.text;
}
Subtitle.Smi.smi2txt = function(smis) {
	let result = "";
	for (let i = 0; i < smis.length; i++) {
		result += smis[i].toTxt() + "\n";
	}
	return result;
}

function sToAttrColor(soColor) {
	if (typeof soColor != 'string') {
		return "FFFFFF";
	}
	if (soColor[0] == '#' && soColor.length == 7) {
		return soColor.substring(1);
	}
	switch (soColor) {
		case "red"                 : return "FF0000";
		case "crimson"             : return "DC143C";
		case "firebrick"           : return "B22222";
		case "maroon"              : return "800000";
		case "darkred"             : return "8B0000";
		case "brown"               : return "A52A2A";
		case "sienna"              : return "A0522D";
		case "saddlebrown"         : return "8B4513";
		case "indianred"           : return "CD5C5C";
		case "rosybrown"           : return "BC8F8F";
		case "lightcoral"          : return "F08080";
		case "salmon"              : return "FA8072";
		case "darksalmon"          : return "E9967A";
		case "coral"               : return "FF7F50";
		case "tomato"              : return "FF6347";
		case "sandybrown"          : return "F4A460";
		case "lightsalmon"         : return "FFA07A";
		case "peru"                : return "CD853F";
		case "chocolate"           : return "D2691E";
		case "orangered"           : return "FF4500";
		case "orange"              : return "FFA500";
		case "darkorange"          : return "FF8C00";
		case "tan"                 : return "D2B48C";
		case "peachpuff"           : return "FFDAB9";
		case "bisque"              : return "FFE4C4";
		case "moccasin"            : return "FFE4B5";
		case "navajowhite"         : return "FFDEAD";
		case "wheat"               : return "F5DEB3";
		case "burlywood"           : return "DEB887";
		case "darkgoldenrod"       : return "B8860B";
		case "goldenrod"           : return "DAA520";
		case "gold"                : return "FFD700";
		case "yellow"              : return "FFFF00";
		case "lightgoldenrodyellow": return "FAFAD2";
		case "palegoldenrod"       : return "EEE8AA";
		case "khaki"               : return "F0E68C";
		case "darkkhaki"           : return "BDB76B";
		case "lawngreen"           : return "7CFC00";
		case "greenyellow"         : return "ADFF2F";
		case "chartreuse"          : return "7FFF00";
		case "lime"                : return "00FF00";
		case "limegreen"           : return "32CD32";
		case "yellowgreen"         : return "9ACD32";
		case "olive"               : return "808000";
		case "olivedrab"           : return "6B8E23";
		case "darkolivegreen"      : return "556B2F";
		case "forestgreen"         : return "228B22";
		case "darkgreen"           : return "006400";
		case "green"               : return "008000";
		case "seagreen"            : return "2E8B57";
		case "mediumseagreen"      : return "3CB371";
		case "darkseagreen"        : return "8FBC8F";
		case "lightgreen"          : return "90EE90";
		case "palegreen"           : return "98FB98";
		case "springgreen"         : return "00FF7F";
		case "mediumspringgreen"   : return "00FA9A";
		case "teal"                : return "008080";
		case "darkcyan"            : return "008B8B";
		case "lightseagreen"       : return "20B2AA";
		case "mediumaquamarine"    : return "66CDAA";
		case "cadetblue"           : return "5F9EA0";
		case "steelblue"           : return "4682B4";
		case "aquamarine"          : return "7FFFD4";
		case "powderblue"          : return "B0E0E6";
		case "paleturquoise"       : return "AFEEEE";
		case "lightblue"           : return "ADD8E6";
		case "lightsteelblue"      : return "B0C4DE";
		case "skyblue"             : return "87CEEB";
		case "lightskyblue"        : return "87CEFA";
		case "mediumturquoise"     : return "48D1CC";
		case "turquoise"           : return "40E0D0";
		case "darkturquoise"       : return "00CED1";
		case "aqua"                : return "00FFFF";
		case "cyan"                : return "00FFFF";
		case "deepskyblue"         : return "00BFFF";
		case "dodgerblue"          : return "1E90FF";
		case "cornflowerblue"      : return "6495ED";
		case "royalblue"           : return "4169E1";
		case "blue"                : return "0000FF";
		case "mediumblue"          : return "0000CD";
		case "navy"                : return "000080";
		case "darkblue"            : return "00008B";
		case "midnightblue"        : return "191970";
		case "darkslateblue"       : return "483D8B";
		case "slateblue"           : return "6A5ACD";
		case "mediumslateblue"     : return "7B68EE";
		case "mediumpurple"        : return "9370DB";
		case "darkorchid"          : return "9932CC";
		case "darkviolet"          : return "9400D3";
		case "blueviolet"          : return "8A2BE2";
		case "mediumorchid"        : return "BA55D3";
		case "plum"                : return "DDA0DD";
		case "lavender"            : return "E6E6FA";
		case "thistle"             : return "D8BFD8";
		case "orchid"              : return "DA70D6";
		case "violet"              : return "EE82EE";
		case "indigo"              : return "4B0082";
		case "darkmagenta"         : return "8B008B";
		case "purple"              : return "800080";
		case "mediumvioletred"     : return "C71585";
		case "deeppink"            : return "FF1493";
		case "fuchsia"             : return "FF00FF";
		case "magenta"             : return "FF00FF";
		case "hotpink"             : return "FF69B4";
		case "palevioletred"       : return "DB7093";
		case "lightpink"           : return "FFB6C1";
		case "pink"                : return "FFC0CB";
		case "mistyrose"           : return "FFE4E1";
		case "blanchedalmond"      : return "FFEBCD";
		case "lightyellow"         : return "FFFFE0";
		case "cornsilk"            : return "FFF8DC";
		case "antiquewhite"        : return "FAEBD7";
		case "papayawhip"          : return "FFEFD5";
		case "lemonchiffon"        : return "FFFACD";
		case "beige"               : return "F5F5DC";
		case "linen"               : return "FAF0E6";
		case "oldlace"             : return "FDF5E6";
		case "lightcyan"           : return "E0FFFF";
		case "aliceblue"           : return "F0F8FF";
		case "whitesmoke"          : return "F5F5F5";
		case "lavenderblush"       : return "FFF0F5";
		case "floralwhite"         : return "FFFAF0";
		case "mintcream"           : return "F5FFFA";
		case "ghostwhite"          : return "F8F8FF";
		case "honeydew"            : return "F0FFF0";
		case "seashell"            : return "FFF5EE";
		case "ivory"               : return "FFFFF0";
		case "azure"               : return "F0FFFF";
		case "snow"                : return "FFFAFA";
		case "white"               : return "FFFFFF";
		case "gainsboro"           : return "DCDCDC";
		case "lightgrey"           : return "D3D3D3";
		case "silver"              : return "C0C0C0";
		case "darkgray"            : return "A9A9A9";
		case "lightslategray"      : return "778899";
		case "slategray"           : return "708090";
		case "gray"                : return "808080";
		case "dimgray"             : return "696969";
		case "darkslategray"       : return "2F4F4F";
		case "black"               : return "000000";
	}
	return soColor;
}
Subtitle.Smi.colorToAttr = function(soColor) {
	return sToAttrColor(soColor);
}
Subtitle.Smi.colorFromAttr = function(attrColor) {
	return "#" + attrColor;
}

Subtitle.Smi.Status = function() {
	this.b = 0;
	this.i = 0;
	this.u = 0;
	this.fs = [];
	this.fn = [];
	this.fc = [];
	this.fade = [];
	this.shake = [];
	this.typing = [];
	this.fontAttrs = [];
}
Subtitle.Smi.Status.prototype.setB = function(isOpen) {
	if (isOpen) this.b++;
	else if (this.b > 0) this.b--;
	return this;
}
Subtitle.Smi.Status.prototype.setI = function(isOpen) {
	if (isOpen) this.i++;
	else if (this.i > 0) this.i--;
	return this;
}
Subtitle.Smi.Status.prototype.setU = function(isOpen) {
	if (isOpen) this.u++;
	else if (this.u > 0) this.u--;
	return this;
}
Subtitle.Smi.Status.prototype.setFont = function(attrs) {
	if (attrs != null) {
		let thisAttrs = [];
		for (let i = 0; i < attrs.length; i++) {
			thisAttrs[i] = attrs[i][0];
			switch (attrs[i][0]) {
				case "size":
					if (isFinite(attrs[i][1])) {
						this.fs.push(Number(attrs[i][1]));
					}
					break;
					
				case "face":
					this.fn.push(attrs[i][1]);
					break;
					
				case "color":
					this.fc.push(sToAttrColor(attrs[i][1]));
					break;
					
				case "fade":
					let fade = attrs[i][1];
					if (fade == "in") {
						fade = 1;
					} else if (fade == "out") {
						fade = -1;
					} else {
						if (typeof fade == "string" && fade.length == 7 && fade[0] == "#") {
							// 16진수 맞는지 확인
							if (!isFinite("0x" + fade.substring(1))) {
								fade = 0;
							}
						} else {
							fade = 0;
						}
					}
					this.fade.push(fade);
					break;
					
				case "shake": {
					let shake = { ms: 125, size: 1 };
					if (attrs[i][1]) {
						let attr = attrs[i][1].split(",");
						if (isFinite(attr[0])) shake.ms   = Number(attr[0]);
						if (isFinite(attr[1])) shake.size = Number(attr[1]);
					}
					this.shake.push(shake);
					break;
				}
					
				case "typing": {
					let attr = attrs[i][1].split(' ');
					let mode = attr[0];
					let match = null;
					let tAttr = null;

					if (mode == "typewriter") {
						tAttr = new Subtitle.Attr.TypingAttr(Typing.Mode.typewriter);
						
					} else if (match = /typewriter\(([0-9]+),([0-9]+)\)/.exec(mode)) {
						tAttr = new Subtitle.Attr.TypingAttr(Typing.Mode.typewriter, Number(match[1]), Number(match[2]));
						
					} else if (mode.substring(0, 8) == "keyboard") {
						if (mode == "keyboard") {
							tAttr = new Subtitle.Attr.TypingAttr(Typing.Mode.keyboard);
							
						} else if (mode.length == 10) {
							let s = ((mode[8] == '(') ? 1 : ((mode[8] == '[') ? 0 : -1));
							let e = ((mode[9] == ')') ? 1 : ((mode[9] == ']') ? 0 : -1));
							if (s > -1 && e > -1) {
								tAttr = new Subtitle.Attr.TypingAttr(Typing.Mode.keyboard, s, e);
							}
							
						} else if (match = /keyboard\(([0-9]+),([0-9]+)\)/.exec(mode)) {
							tAttr = new Subtitle.Attr.TypingAttr(Typing.Mode.keyboard, Number(match[1]), Number(match[2]));
						}
					}
					
					if (tAttr == null) {
						thisAttrs[i] = "";
					} else {
						if (attr.length > 1) {
							switch (attr[1]) {
								case "invisible":
									tAttr.cursor = Typing.Cursor.invisible;
									break;
								case "hangeul":
									tAttr.cursor = Typing.Cursor.hangeul;
									break;
							}
						}
						this.typing.push(tAttr);
					}
					break;
				}
			}
		}
		this.fontAttrs.push(thisAttrs);
		
	} else if (this.fontAttrs != null && this.fontAttrs.length) {
		let lastAttrs = this.fontAttrs[this.fontAttrs.length - 1];
		for (let i = 0; i < lastAttrs.length; i++) {
			switch (lastAttrs[i]) {
				case "size":
					this.fs.pop()
					break;
				case "face":
					this.fn.pop();
					this.break;
				case "color":
					this.fc.pop();
					break;
				case "fade":
					this.fade.pop();
					break;
				case "shake":
					this.shake.pop();
					break;
				case "typing":
					this.typing.pop();
					break;
			}
		}
		this.fontAttrs.pop();
	}
	return this;
}
Subtitle.Smi.SetStyle = function(attr, status) {
	attr.b = status.b > 0;
	attr.i = status.i > 0;
	attr.u = status.u > 0;
	attr.fs = (status.fs.length > 0) ? status.fs[status.fs.length - 1] : 0;
	attr.fn = (status.fn.length > 0) ? status.fn[status.fn.length - 1] : "";
	attr.fc = (status.fc.length > 0) ? status.fc[status.fc.length - 1] : "";
	attr.fade = (status.fade.length > 0) ? status.fade[status.fade.length - 1] : 0;
	attr.shake = (status.shake.length > 0) ? status.shake[status.shake.length - 1] : null;
	attr.typing = (status.typing.length > 0) ? status.typing[status.typing.length - 1] : null;
}
Subtitle.Smi.SetFurigana = function(attr, furigana) {
	attr.furigana = furigana ? furigana : null;
}
Subtitle.Smi.toAttr = function(text) {
	let status = new Subtitle.Smi.Status();
	let last = new Subtitle.Attr();
	let result = [last];
	let ruby = null;
	let furigana = null;
	
	let state = null;
	let pos = 0;
	
	let tag = null;
	let attr = null;
	let value = null;
	
	function openTag() {
		switch (tag.name.toUpperCase()) {
			case "B":
				if (last.text.length > 0)
					result.push((last = new Subtitle.Attr()));
				Subtitle.Smi.SetStyle(last, status.setB(true));
				break;
			case "I":
				if (last.text.length > 0)
					result.push((last = new Subtitle.Attr()));
				Subtitle.Smi.SetStyle(last, status.setI(true));
				break;
			case "U":
				if (last.text.length > 0)
					result.push((last = new Subtitle.Attr()));
				Subtitle.Smi.SetStyle(last, status.setU(true));
				break;
			case "FONT":
				if (last.text.length > 0)
					result.push((last = new Subtitle.Attr()));
				{
					let attrs = [];
					for (let name in tag.attrs) {
						attrs.push([name, tag.attrs[name]]);
					}
					Subtitle.Smi.SetStyle(last, status.setFont(attrs));
				}
				break;
			case "RUBY":
				if (last.text.length > 0)
					result.push((last = new Subtitle.Attr()));
				ruby = last;
				break;
			case "RT":
				if (last.text.length > 0)
					last = new Subtitle.Attr();
				furigana = last;
				break;
			case "RP":
				last = new Subtitle.Attr(); // 정크 데이터
				break;
			case "BR":
				last.text += "\n";
				break;
		}
		tag = null;
	}
	function closeTag(tagName) {
		switch (tagName.toUpperCase()) {
			case "B":
				if (last.text.length > 0)
					result.push((last = new Subtitle.Attr()));
				Subtitle.Smi.SetStyle(last, status.setB(false));
				break;
			case "I":
				if (last.text.length > 0)
					result.push((last = new Subtitle.Attr()));
				Subtitle.Smi.SetStyle(last, status.setI(false));
				break;
			case "U":
				if (last.text.length > 0)
					result.push((last = new Subtitle.Attr()));
				Subtitle.Smi.SetStyle(last, status.setU(false));
				break;
			case "FONT":
				if (last.text.length > 0)
					result.push((last = new Subtitle.Attr()));
				Subtitle.Smi.SetStyle(last, status.setFont(null));
				break;
			case "RUBY":
				if (last.text.length > 0)
					result.push((last = new Subtitle.Attr()));
				break;
			case "RT":
				if (ruby) {
					Subtitle.Smi.SetFurigana(ruby, furigana);
					furigana = null;
					last = ruby;
				}
				break;
			case "RP":
				if (furigana) last = furigana;
				break;
			default:
				break;
		}
	}
	
	for (let pos = 0; pos < text.length; pos++) {
		let c = text[pos];
		switch (state) {
			case '/': { // 태그?!
				state = '<';
				if (c == '/') { // 종료 태그 시작일 경우
					let end = text.indexOf('>', pos);
					if (end < 0) {
						// 태그 끝이 없음
						pos = text.length;
						break;
					}
					closeTag(text.substring(pos + 1, end));
					pos = end;
					state = null;
					break;
				}
				// 종료 태그 아닐 경우 아래로 이어서 진행
				tag = { name: "", attrs: {} };
			}
			case '<': { // 태그명
				switch (c) {
					case '>': { // 태그 종료
						openTag();
						state = null;
						break;
					}
					case ' ':
					case '\t': { // 태그명 끝
						state = '>';
						break;
					}
					default: {
						tag.name += c;
						break;
					}
				}
				break;
			}
			case '>': { // 태그 내
				switch (c) {
					case '>': { // 태그 종료
						openTag();
						state = null;
						break;
					}
					case ' ': 
					case '\t':
					case '<':
					case '&': {
						break;
					}
					default: { // 속성명 시작
						attr = c;
						state = 'a';
						break;
					}
				}
				break;
			}
			case 'a': { // 속성명
				switch (c) {
					case '>': { // 태그 종료
						tag.attrs[attr] = attr;
						openTag();
						state = null;
						break;
					}
					case '=': { // 속성값 시작
						state = '=';
						break;
					}
					case ' ':
					case '\t': { // 일단은 속성이 끝나지 않을 걸로 간주
						state = '`';
						break;
					}
					default: {
						attr += c;
					}
				}
				break;
			}
			case '`': { // 속성명+공백문자
				switch (c) {
					case '>': { // 태그 종료
						tag.attrs[attr] = attr;
						openTag();
						state = null;
						break;
					}
					case '=': { // 속성값 시작
						state = '=';
						break;
					}
					case ' ':
					case '\t': { // 일단은 속성이 끝나지 않을 걸로 간주
						break;
					}
					default: { // 속성값 없는 속성으로 확정, 새 속성 시작
						tag.attrs[attr] = attr;
						attr = c;
						state = 'a';
					}
				}
				break;
			}
			case '=': { // 속성값 시작 전
				switch (c) {
					case '>': { // 태그 종료
						tag.attrs[attr] = "";
						openTag();
						state = null;
						break;
					}
					case '"': { // 속성값 따옴표 시작
						value = "";
						state = '"';
						break;
					}
					case "'": { // 속성값 따옴표 시작
						value = "";
						state = "'";
						break;
					}
					case ' ': { // 일단은 속성이 끝나지 않을 걸로 간주
						break;
					}
					case '\t': {
						break;
					}
					default: {
						value = c;
						state = '~';
					}
				}
				break;
			}
			case '~': { // 따옴표 없는 속성값
				switch (c) {
					case '>': { // 태그 종료
						tag.attrs[attr] = value;
						openTag();
						state = null;
						break;
					}
					case ' ':
					case '\t': { // 속성 종료
						tag.attrs[attr] = value;
						state = '>';
						break;
					}
					default: {
						value += c;
					}
				}
				break;
			}
			case '"': {
				switch (c) {
					case '"': { // 속성 종료
						tag.attrs[attr] = value;
						state = '>';
						break;
					}
					default: {
						value += c;
					}
				}
				break;
			}
			case "'": {
				switch (c) {
					case "'": { // 속성 종료
						tag.attrs[attr] = value;
						state = '>';
						break;
					}
					default: {
						value += c;
					}
				}
				break;
			}
			case '!': { // 주석
				if ((pos + 3 <= text.length) && (text.substring(pos, pos+3) == "-->")) {
					state = null;
					pos += 2;
				}
				break;
			}
			default: { // 텍스트
				switch (c) {
					case '<': { // 태그 시작
						if ((pos + 4 <= text.length) && (text.substring(pos, pos+4) == "<!--")) {
							state = '!';
							pos += 3;
						} else {
							state = '/';
						}
						break;
					}
					case '\n': { // 줄바꿈 무자 무시
						break;
					}
					default: {
						last.text += c;
					}
				}
			}
		}
	}
	
	return result;
}
Subtitle.Smi.prototype.toAttr = function() {
	return Subtitle.Smi.toAttr(this.text);
}
Subtitle.Smi.prototype.fromAttr = function(attrs) {
	this.text = Subtitle.Smi.fromAttr(attrs).split("\n").join("<br>");
	return this;
}
Subtitle.Smi.fromAttr = function(attrs) {
	let text = "";
	let lastAttrs = [];
	
	let last = new Subtitle.Attr();
	for (let i = 0; i < attrs.length; i++) {
		let attr = attrs[i];
		
		if (last.furigana || attr.furigana) {
			// <RUBY> 태그 적용 시 무조건 태그 닫고 열기
			
			if (last.b) text += "</B>";
			if (last.i) text += "</I>";
			if (last.u) text += "</U>";
			
			// 기존에 속성이 있었을 때 닫는 태그
			if (last.fs > 0 || !last.fn == ("") || !last.fc == ("") || last.fade != 0 || last.shake != null || last.typing != null)
				text += "</FONT>";
			
			if (attr.furigana) {
				text += "<RUBY>";
			}
			
			if (attr.b) text += "<B>";
			if (attr.i) text += "<I>";
			if (attr.u) text += "<U>";
			
			// 신규 속성이 있을 때 여는 태그
			if (attr.fs > 0 || !attr.fn == ("") || !attr.fc == ("") || attr.fade != 0 || attr.shake != null || attr.typing != null) {
				text += "<FONT";
				if (attr.fs   >  0 ) text += " size=\"" + attr.fs + "\"";
				if (attr.fn   != "") text += " face=\"" + attr.fn + "\"";
				if (attr.fc   != "") text += " color=\""+ Subtitle.Smi.colorFromAttr(attr.fc) + "\"";
				if (attr.fade != 0 ) text += " fade=\"" + (attr.fade == 1 ? "in" : (attr.fade == -1 ? "out" : attr.fade)) + "\"";
				if (attr.shake != null) text += " shake=\"" + attr.shake.ms + "," + attr.shake.size + "\"";
				if (attr.typing != null) text += " typing=\"" + Typing.Mode.toString(attr.typing.mode) + "(" + attr.typing.start + "," + attr.typing.end + ") " + Typing.Cursor.toString(attr.typing.cursor) + "\"";
				text += ">";
			}
			
			if (attr.furigana) {
				text += "<RT><RP>(</RP>" + Subtitle.Smi.fromAttr([attr.furigana]) + "<RP>)</RP></RT></RUBY>";
			}
			
			last = new Subtitle.Attr();
			
		} else {
			if (!last.b && attr.b) text += "<B>";
			else if (last.b && !attr.b) text += "</B>";
			
			if (!last.i && attr.i) text += "<I>";
			else if (last.i && !attr.i) text += "</I>";
			
			if (!last.u && attr.u) text += "<U>";
			else if (last.u && !attr.u) text += "</U>";
			
			if ( last.fs   != attr.fs
					||  last.fn   != attr.fn
					||  last.fc   != attr.fc
					||  last.fade != attr.fade
					|| (last.shake == null && attr.shake != null)
					|| (last.shake != null && attr.shake == null)
					|| (last.typing == null && attr.typing != null)
					|| (last.typing != null && attr.typing == null)
			) {
				// 기존에 속성이 있었을 때만 닫는 태그
				if (last.fs > 0 || !last.fn == ("") || !last.fc == ("") || last.fade != 0 || last.shake != null || last.typing != null)
					text += "</FONT>";
				
				// 신규 속성이 있을 때만 여는 태그
				if (attr.fs > 0 || !attr.fn == ("") || !attr.fc == ("") || attr.fade != 0 || attr.shake != null || attr.typing != null) {
					text += "<FONT";
					if (attr.fs   >  0 ) text += " size=\"" + attr.fs + "\"";
					if (attr.fn   != "") text += " face=\"" + attr.fn + "\"";
					if (attr.fc   != "") text += " color=\""+ Subtitle.Smi.colorFromAttr(attr.fc) + "\"";
					if (attr.fade != 0 ) text += " fade=\"" + (attr.fade == 1 ? "in" : (attr.fade == -1 ? "out" : attr.fade)) + "\"";
					if (attr.shake != null) text += " shake=\"" + attr.shake.ms + "," + attr.shake.size + "\"";
					if (attr.typing != null) text += " typing=\"" + Typing.Mode.toString(attr.typing.mode) + "(" + attr.typing.start + "," + attr.typing.end + ") " + Typing.Cursor.toString(attr.typing.cursor) + "\"";
					text += ">";
				}
			}
		}
		
		text += $("<a>").text(attr.text).html();
		last = attr;
	}
	
	return text;
}

Subtitle.Smi.prototype.toSync = function() {
	return new Subtitle.SyncAttr(this.start, null, this.syncType, null, this.toAttr());
}
Subtitle.Smi.prototype.fromSync = function(sync) {
	this.start = sync.start;
	this.syncType = sync.startType;
	this.fromAttr(sync.text);
	return this;
}

Subtitle.Smi.getLineWidth = function(text) {
	return Subtitle.Width.getWidth(Subtitle.Smi.toAttr(text));
}

Subtitle.Smi.Color = function(index, target, color) {
	this.index = index;
	
	this.r = this.tr = Subtitle.Smi.Color.v(color.substring(0, 2));
	this.g = this.tg = Subtitle.Smi.Color.v(color.substring(2, 4));
	this.b = this.tb = Subtitle.Smi.Color.v(color.substring(4, 6));
	
	if (target == 1) {
		this.r = this.g = this.b = 0;
	} else if (target == -1) {
		this.tr = this.tg = this.tb = 0;
	} else {
		if (typeof target == "string" && target.length == 7 && target[0] == "#") {
			// 16진수 맞는지 확인
			target = target.substring(1);
			if (isFinite("0x" + target)) {
				this.tr = Subtitle.Smi.Color.v(target.substring(0, 2));
				this.tg = Subtitle.Smi.Color.v(target.substring(2, 4));
				this.tb = Subtitle.Smi.Color.v(target.substring(4, 6));
			}
		}
	}
}
Subtitle.Smi.Color.v = function(c) {
	if (c.length == 1) {
		if (c >= '0' && c <= '9')
			return c.charCodeAt() - 48
		if (c >= 'a' && c <= 'z')
			return c.charCodeAt() - 87;
		if (c >= 'A' && c <= 'Z')
			return c.charCodeAt() - 55;
		return 0;
		
	} else {
		let v = 0;
		for (let i = 0; i < c.length; i++) {
			v = v * 16 + Subtitle.Smi.Color.v(c[i]);
		}
		return v;
	}
}
Subtitle.Smi.Color.c = function(v) {
	return v < 10 ? String.fromCharCode(v + 48) : String.fromCharCode(v + 55);
}
Subtitle.Smi.Color.hex = function(v) {
	return "" + Subtitle.Smi.Color.c(v / 16) + Subtitle.Smi.Color.c(v % 16);
}
Subtitle.Smi.Color.prototype.get = function(value, total) {
	return Subtitle.Smi.Color.hex(((this.r * (total - value)) + (this.tr * value)) / total)
	     + Subtitle.Smi.Color.hex(((this.g * (total - value)) + (this.tg * value)) / total)
	     + Subtitle.Smi.Color.hex(((this.b * (total - value)) + (this.tb * value)) / total);
}
Subtitle.Smi.normalize = function(smis, withComment=false) {
	let origin = new Subtitle.SmiFile();
	origin.body = smis;
	origin.fromTxt(origin.toTxt());
	let result = {
			origin: origin.body
		,	result: smis
		,	logs: []
	};
	let added = 0;

	// 중간 싱크 재계산
	let startIndex = -1;
	for (let i = 1; i < smis.length; i++) {
		if (smis[i].syncType == Subtitle.SyncType.inner) {
			if (startIndex < 0) {
				startIndex = i - 1;
			}
		} else {
			if (startIndex >= 0) {
				let endIndex = i;
				if (smis[startIndex].syncType == smis[endIndex].syncType) {
					let startSync = smis[startIndex].start;
					let endSync = smis[endIndex].start;
					let count = endIndex - startIndex;

					for (let j = 1; j < count; j++) {
						smis[startIndex + j].start = Math.round(((count - j) * startSync + j * endSync) / count);
					}
				}
				startIndex = -1;
			}
		}
	}

	for (let i = 0; i < smis.length - 1; i++) {
		let smi = smis[i];
		/*
		if (smi.syncType != smis[i + 1].syncType) {
			// 전후 싱크 타입이 맞을 때만 안전함
			continue;
		}
		*/
		
		let attrs = smi.toAttr();
		
		let hasFade = false;
		let hasShake = false;
		let hasTyping = false;
		let type = null;
		for (let j = 0; j < attrs.length; j++) {
			if (attrs[j].fade != 0) {
				hasFade = true;
			}
			if (attrs[j].shake) {
				hasShake = true;
			}
			if (attrs[j].typing) {
				hasTyping = true;
			}
		}
		
		if (hasShake) {
			// 흔들기는 한 싱크에 하나만 가능
			let attrIndex = -1;
			let attr = null;
			let isLastAttr = false;
			for (let j = 0; j < attrs.length; j++) {
				if (attrs[j].shake != null) {
					attr = attrs[(attrIndex = j)];
					let remains = "";
					for (let k = j + 1; k < attrs.length; k++) {
						remains += attrs[k].text;
					}
					isLastAttr = (remains.length == 0) || (remains[0] == "\n");
					if (!isLastAttr) {
						let length = 0;
						for (let k = j + 1; k < attrs.length; k++) {
							length += attrs[k].text.length;
						}
						isLastAttr = (length == 0);
					}
					break;
				}
			}
			if (attr == null) {
				continue;
			}
			
			let shake = attr.shake;
			attr.shake = null;
			attr.text = "{SL}" + attr.text + "{SR}";
			
			let start = smi.start;
			let end = smis[i + 1].start;
			let count = Math.floor(((end - start) / shake.ms) + 0.5);
			
			let j = attrIndex - 1;
			for (; j >= 0; j--) {
				let text = attrs[j].text;
				let brIndex = text.lastIndexOf("\n");
				if (brIndex >= 0) {
					attrs[j].text = text.substring(0, brIndex + 1) + "{ST}" + text.substring(brIndex + 1);
					break;
				}
			}
			if (j < 0) {
				attrs[0].text = "{ST}" + attrs[0].text;
			}
			for (j = attrIndex + 1; j < attrs.length; j++) {
				let text = attrs[j].text;
				let brIndex = text.indexOf("\n");
				if (brIndex >= 0) {
					attrs[j].text = text.substring(0, brIndex) + "{SB}" + text.substring(brIndex);
					break;
				}
			}
			if (j >= attrs.length) {
				attrs[attrs.length - 1].text = attrs[attrs.length - 1].text + "{SB}";
			}
			
			// 페이드 효과 추가 처리
			let fadeColors = [];
			if (hasFade) {
				for (let j = 0; j < attrs.length; j++) {
					if (attrs[j].fade != 0) {
						fadeColors.push(new Subtitle.Smi.Color(j, attrs[j].fade, ((attrs[j].fc.length == 6) ? attrs[j].fc : "ffffff")));
						attrs[j].fade = 0;
					}
				}
				if (fadeColors.length == 0) {
					continue;
				}
			}
			
			// 좌우로 흔들기
			// 플레이어에서 사이즈 미지원해도 좌우로는 흔들리도록
			let LRmin = "<font size=\"" + (3 * shake.size) + "\"></font>";
			let LRmid = "<font size=\"" + (3 * shake.size) + "\"> </font>";
			let LRmax = "<font size=\"" + (3 * shake.size) + "\">  </font>";
			
			// 상하로 흔들기
			// 플레이어에서 사이즈 미지원하면 상하로 흔들리지 않음
			let TBmin = "<font size=\"" + (0 * shake.size) + "\">　</font>";
			let TBmid = "<font size=\"" + (1 * shake.size) + "\">　</font>";
			let TBmax = "<font size=\"" + (2 * shake.size) + "\">　</font>";
			
			smis.splice(i, 1);
			for (let j = 0; j < count; j++) {
				/*
				 * ５０３
				 * ２※６
				 * ７４１
				 */
				let step = j % 8;
				
				// 페이드 효과 추가 처리
				for (let k = 0; k < fadeColors.length; k++) {
					let color = fadeColors[k];
					attrs[color.index].fc = color.get(1 + 2 * j, 2 * count);
				}
				let text = Subtitle.Smi.fromAttr(attrs).split("\n").join("<br>");
				
				// 좌우로 흔들기
				switch (step) {
					case 2:
					case 5:
					case 7:
						text = text.split("{SL}").join(LRmin).split("{SR}").join(LRmax);
						break;
					case 0:
					case 4:
						text = text.split("{SL}").join(LRmid).split("{SR}").join(LRmid);
						break;
					default:
						text = text.split("{SL}").join(LRmax).split("{SR}").join(LRmin);
				}
				
				// 상하로 흔들기
				switch (step) {
					case 0:
					case 3:
					case 5:
						text = text.split("{ST}").join(TBmin + "<br>").split("{SB}").join("<br>" + TBmax);
						break;
					case 2:
					case 6:
						text = text.split("{ST}").join(TBmid + "<br>").split("{SB}").join("<br>" + TBmid);
						break;
					default:
						text = text.split("{ST}").join(TBmax + "<br>").split("{SB}").join("<br>" + TBmin);
				}
				
				smis.splice(i + j, 0, new Subtitle.Smi((start * (count - j) + end * (j)) / count, (j == 0 ? smi.syncType : Subtitle.SyncType.inner), text));
			}
			if (withComment) {
				smis[i].text = "<!-- End=" + end + "\n" + smi.text.split("<").join("<​").split(">").join("​>") + "\n-->\n" + smis[i].text;
			}
			result.logs.push({
					from: [i - added, i - added + 1]
				,	to  : [i, i + count]
				,	start: start
				,	end: end
			});
			let add = count - 1;
			i += add;
			added += add;

		} else if (hasTyping) {
			// 타이핑은 한 싱크에 하나만 가능
			let attrIndex = -1;
			let attr = null;
			let isLastAttr = false;
			for (let j = 0; j < attrs.length; j++) {
				if (attrs[j].typing != null) {
					attr = attrs[(attrIndex = j)];
					let remains = "";
					for (let k = j + 1; k < attrs.length; k++) {
						remains += attrs[k].text;
					}
					isLastAttr = (remains.length == 0) || (remains[0] == "\n");
					if (!isLastAttr) {
						let length = 0;
						for (let k = j + 1; k < attrs.length; k++) {
							length += attrs[k].text.length;
						}
						isLastAttr = (length == 0);
					}
					break;
				}
			}
			if (attr == null) {
				continue;
			}
			
			let types = Typing.toType(attr.text, attr.typing.mode, attr.typing.cursor);
			let width = Subtitle.Smi.getLineWidth(attr.text);

			let start = smi.start;
			let end = smis[i + 1].start;
			let count = types.length - attr.typing.end - attr.typing.start;
			
			if (count < 1) {
				continue;
			}

			let typingStart = attr.typing.start;
			attr.typing = null;
			
			// 페이드 효과 추가 처리
			let fadeColors = [];
			if (hasFade) {
				for (let j = 0; j < attrs.length; j++) {
					if (attrs[j].fade != 0) {
						fadeColors.push(new Subtitle.Smi.Color(j, attrs[j].fade, ((attrs[j].fc.length == 6) ? attrs[j].fc : "ffffff")));
						attrs[j].fade = 0;
					}
				}
				if (fadeColors.length == 0) {
					continue;
				}
			}
			
			smis.splice(i, 1);
			for (let j = 0; j < count; j++) {
				let text = types[j + typingStart];
				attr.text = Subtitle.Width.getAppendToTarget(Subtitle.Smi.getLineWidth(text), width) + (isLastAttr ? "​" : "");
				let newAttrs = new Subtitle.Smi(null, null, text).toAttr();
				for (let k = 0; k < newAttrs.length; k++) {
					newAttrs[k].b = attr.b;
					newAttrs[k].i = attr.i;
					newAttrs[k].fc = attr.fc;
					newAttrs[k].fn = attr.fn;
					newAttrs[k].fs = attr.fs;
				}
				
				// 페이드 효과 추가 처리
				for (let k = 0; k < fadeColors.length; k++) {
					let color = fadeColors[k];
					attrs[color.index].fc = color.get(1 + 2 * j, 2 * count);
				}
				
				let tAttrs = attrs.slice(0, attrIndex);
				tAttrs = tAttrs.concat(newAttrs);
				tAttrs.push(attr);
				tAttrs = tAttrs.concat(attrs.slice(attrIndex + 1));
				
				smis.splice(i + j, 0, new Subtitle.Smi((start * (count - j) + end * (j)) / count, (j == 0 ? smi.syncType : Subtitle.SyncType.inner)).fromAttr(tAttrs));
			}
			if (withComment) {
				smis[i].text = "<!-- End=" + end + "\n" + smi.text.split("<").join("<​").split(">").join("​>") + "\n-->\n" + smis[i].text;
			}
			result.logs.push({
					from: [i - added, i - added + 1]
				,	to  : [i, i + count]
				,	start: start
				,	end: end
			});
			let add = count - 1;
			i += add;
			added += add;
			
		} else if (hasFade) {
			let start = smi.start;
			let end = smis[i + 1].start;
			let count = Math.round((end - start) * 24 / 1001.0); // 23.976fps로 가정
			
			let fadeColors = [];
			for (let j = 0; j < attrs.length; j++) {
				if (attrs[j].fade != 0) {
					fadeColors.push(new Subtitle.Smi.Color(j, attrs[j].fade, ((attrs[j].fc.length == 6) ? attrs[j].fc : "ffffff")));
					attrs[j].fade = 0;
				}
			}
			if (fadeColors.length == 0) {
				continue;
			}
			
			for (let j = 0; j < fadeColors.length; j++) {
				let color = fadeColors[j];
				attrs[color.index].fc = color.get(1, 2 * count);
			}
			smi.fromAttr(attrs);
			for (let j = 1; j < count; j++) {
				for (let k = 0; k < fadeColors.length; k++) {
					let color = fadeColors[k];
					attrs[color.index].fc = color.get(1 + 2 * j, 2 * count);
				}
				smis.splice(i + j, 0, new Subtitle.Smi((start * (count - j) + end * j) / count, Subtitle.SyncType.inner).fromAttr(attrs));
			}
			if (withComment) {
				smis[i].text = "<!-- End=" + end + "\n" + smi.text.split("<").join("<​").split(">").join("​>") + "\n-->\n" + smis[i].text;
			}
			result.logs.push({
					from: [i - added, i - added + 1]
				,	to  : [i, i + count]
				,	start: start
				,	end: end
			});
			let add = count - 1;
			i += add;
			added += add;
			
		}
	}
	
	return result;
}
Subtitle.Smi.fillEmptySync = function(smis) {
	for (let i = 0; i < smis.length - 1; i++) {
		let smi = smis[i];
		
		let lines = smi.text.split("\r\n").join("\n").split('\n');
		if (lines.length < 2) {
			// 한 줄이면 필요 없음
			continue;
		}
		
		let start = smi.start, end = smis[i + 1].start;
		let length = lines.length;
		
		smi.text = lines[0];
		for (let j = 1; j < length; j++) {
			smis.splice(i + j, 0, new Subtitle.Smi((start * (length - j) + end * j) / length, Subtitle.SyncType.inner, lines[j]));
		}
	}
}
Subtitle.SmiFile = function(txt) {
	this.header = ""; // 세부적으로 나누려다가 주석도 있고 해서 일단 패스
	this.footer = "";
	this.body = [];
	if (txt) {
		this.fromTxt(this.text = txt);
	}
}
Subtitle.SmiFile.prototype.toTxt = function() {
	return this.text
	   = ( this.header.split("\r\n").join("\n")
	     + Subtitle.Smi.smi2txt(this.body)
	     + this.footer.split("\r\n").join("\n")
	     ).trim();
}
Subtitle.SmiFile.prototype.fromTxt = function(txt) {
	txt = (this.text = txt).split("\r\n").join("\n");
	this.header = "";
	this.footer = "";
	this.body = [];
	
	let index = 0;
	let pos = 0;
	let last = null;
	
	while ((pos = txt.indexOf('<', index)) >= 0) {
		if (txt.length > pos + 6 && txt.substring(pos, pos + 6).toUpperCase() == ("<SYNC ")) {
			if (last == null) {
				this.header = txt.substring(0, pos);
			} else {
				last.text += txt.substring(index, pos);
			}

			let start = 0;
			index = txt.indexOf('>', pos + 6) + 1;
			if (index == 0) {
				index = txt.length;
				break;
			}
			let attrs = txt.substring(pos + 6, index - 1).toLowerCase().split(' ');
			for (let i = 0; i < attrs.length; i++) {
				let attr = attrs[i];
				if (attr.substring(0, 6) == ("start=")) {
					start = Number(attr.substring(6));
					break;
				}
			}

			this.body.push(last = new Subtitle.Smi(start));
			
		} else if (txt.length > pos + 4 && txt.substring(pos, pos + 3).toUpperCase() == ("<P ")) {
			let endOfP = txt.indexOf('>', pos + 3) + 1;
			if (last == null) {
				this.header = txt.substring(0, pos);
			} else {
				// last.text가 있음 -> <P> 태그가 <SYNC> 태그 바로 뒤에 붙은 게 아님 - 별도 텍스트로 삽입
				last.text += txt.substring(index, last.text ? endOfP : pos);
			}
			index = endOfP;
			if (index == 0) {
				index = txt.length;
				break;
			}
			switch (txt[index - 2]) {
				case ' ':
					last.syncType = Subtitle.SyncType.frame;
					break;
				case '\t':
					last.syncType = Subtitle.SyncType.inner;
					break;
			}
		} else if (txt.length > pos + 6 && txt.substring(pos, pos + 7).toUpperCase() == ("</BODY>")) {
			if (last == null) {
				this.header = txt.substring(0, pos);
				last = { text: "" }; // 아래에서 헤더에 중복으로 추가되지 않도록 함
			} else {
				last.text += txt.substring(index, pos);
			}
			this.footer = txt.substring(pos);
			index = txt.length;
			break;
			
		} else {
			pos++;
			if (last == null) {
				this.header = txt.substring(0, pos);
			} else {
				last.text += txt.substring(index, pos);
			}
			index = pos;
		}
	}

	if (last == null) {
		this.header = txt.substring(0);
	} else {
		last.text += txt.substring(index);
	}

	for (let i = 0; i < this.body.length; i++) {
		let smi = this.body[i];
		if (smi.text.length > 0) {
			if (smi.text[0] == '\n') {
				smi.text = smi.text.substring(1);
			}
			if (smi.text.length > 1 && smi.text[smi.text.length - 1] == '\n') {
				smi.text = smi.text.substring(0, smi.text.length - 1);
			}
		}
	}

	return this;
}

Subtitle.SmiFile.prototype.toSync = function() {
	let result = [];

	if (this.body.length > 0) {
		let i = 0;
		let last = null;
		for (; i + 1 < this.body.length; i++) {
			if (this.body[i].text.split("&nbsp;").join("").length == 0) {
				continue;
			}

			last = this.body[i].toSync();
			last.end = (this.body[i + 1].start > 0 ? this.body[i + 1].start : 0);
			last.endType = this.body[i + 1].syncType;
			result.push(last);
		}
		result.push(last = this.body[i].toSync());
	}

	return result;
}
Subtitle.SmiFile.prototype.fromSync = function(syncs) {
	let smis = [];

	if (syncs.length > 0) {
		let i = 0;
		let last = null;
		smis.push(new Subtitle.Smi().fromSync(syncs[i]));
		smis.push(last = new Subtitle.Smi(syncs[i].end, syncs[i].endType, "&nbsp;"));
		
		for (i = 1; i < syncs.length; i++) {
			if (last.start == syncs[i].start) {
				last.fromAttr(syncs[i].text);
			} else {
				smis.push(new Subtitle.Smi().fromSync(syncs[i]));
			}

			smis.push(last = new Subtitle.Smi(syncs[i].end, syncs[i].endType, "&nbsp;"));
		}
	}

	this.body = smis;
	return this;
}

Subtitle.SmiFile.prototype.antiNormalize = function () {
	let result = [this];
	
	for (let i = 0; i < this.body.length; i++) {
		let smi = this.body[i];
		let afterComment = null;
		
		// 주석 시작점 찾기
		if (!smi.text.startsWith("<!-- End=")) {
			continue;
		}
		
		// 주석 끝 찾기
		let commentEnd = smi.text.indexOf("-->");
		if (commentEnd < 0) {
			continue;
		}
		
		// 주석이 여기에서 온전히 끝났을 경우
		let comment = smi.text.substring(9, commentEnd).trim();
		afterComment = smi.text.substring(commentEnd + 3).trim();
		
		comment = comment.split("<​").join("<").split("​>").join(">");
		try {
			let index = comment.indexOf("\n");
			let syncEnd = Number(index < 0 ? comment : comment.substring(0, index));
			
			// 자동 생성 내용물 삭제하고 주석 내용물 복원
			if (index > 0) {
				comment = comment.substring(index + 1);
			}
			let removeStart = i + (index < 0 ? 0 : 1);
			let removeEnd = removeStart;
			for(; removeEnd < this.body.length; removeEnd++) {
				if (this.body[removeEnd].start >= syncEnd) {
					break;
				}
			}
			if (comment.length > 6 && comment.substring(0, 6).toUpperCase() == "<SYNC ") {
				let newBody = new Subtitle.SmiFile(comment).body;
				if (i > 0) {
					newBody = this.body.slice(0, i).concat(newBody);
				}
				if (removeEnd < this.body.length
						&& !this.body[removeEnd].text.split("&nbsp;").join("").trim()
						&& !newBody[newBody.length - 1].text.split("&nbsp;").join("").trim()) {
					this.body = newBody.concat(this.body.slice(removeEnd + 1));
				} else {
					this.body = newBody.concat(this.body.slice(removeEnd));
				}
				
			} else if (comment.startsWith("Hold=")) {
				removeStart = i;
				let hold = new Subtitle.SmiFile();
				hold.body = this.body.splice(removeStart, removeEnd - removeStart);
				hold.body[0].text = afterComment;
				hold.antiNormalize();
				hold.next = this.body[removeStart];
				
				hold.name = comment = comment.substring(5);
				hold.pos = 1;
				let nameIndex = comment.indexOf("|");
				if (nameIndex) {
					try {
						hold.pos = Number(comment.substring(0, nameIndex));
					} catch (e) {
						console.log(e);
					}
					hold.name = comment.substring(nameIndex + 1);
				}
				result.push(hold);
				i--;
				
			} else {
				this.body[i].text = comment;
				this.body.splice(removeStart, removeEnd - removeStart);
				i--;
			}
			
		} catch (e) {
			console.log(e);
		}
	}
	
	return result;
}



// TODO: SRT

Subtitle.Srt = function(start, end, text) {
	this.start = start ? Math.round(start) : 0;
	this.end   = end   ? Math.round(end  ) : 0;
	this.text = text ? text : "";
}

Subtitle.Srt.prototype.toTxt = function() {
	return Subtitle.Srt.int2Time(this.start) + "-->" + Subtitle.Srt.int2Time(this.end) + "\n" + this.text + "\n";
}
Subtitle.Srt.srt2txt = function(srts) {
	let result = "";
	for (let i = 0; i < srts.length; i++) {
		result += srts[i].toTxt() + "\n";
	}
	return result;
}
Subtitle.Srt.colorToAttr   = Subtitle.Smi.colorToAttr;
Subtitle.Srt.colorFromAttr = Subtitle.Smi.colorFromAttr
Subtitle.Srt.prototype.toAttr   = Subtitle.Smi.prototype.toAttr
Subtitle.Srt.prototype.fromAttr = Subtitle.Smi.prototype.fromAttr

Subtitle.Srt.prototype.toSync = function() {
	return new Subtitle.SyncAttr(this.start, this.end, null, null, this.toAttr());
}
Subtitle.Srt.prototype.fromSync = function(sync) {
	this.start = sync.start;
	this.end = sync.end;
	this.fromAttr(sync.text);
	return this;
}

Subtitle.Srt.int2Time = function(time) {
	let h = Math.floor(time / 3600000);
	let m = Math.floor(time / 60000) % 60;
	let s = Math.floor(time / 1000) % 60;
	let ms= Math.floor(time % 1000);
	return intPadding(h) + ":" + intPadding(m) + ":" + intPadding(s) + "," + intPadding(ms, 3);
}

Subtitle.SrtFile = function(txt) {
	this.body = [];
	if (txt) {
		this.fromTxt(txt);
	}
}
Subtitle.SrtFile.prototype.toTxt = function() {
	let items = [];
	for (let i = 0; i < this.body.length; i++) {
		items.push((i + 1) + "\n" + this.body[i].toTxt());
	}
	return items.join("\n");
}
Subtitle.SrtFile.REG_SRT_SYNC = /^([0-9]{2}:){1,2}[0-9]{2}[,.][0-9]{2,3}( )*-->( )*([0-9]{2}:){1,2}[0-9]{2}[,.][0-9]{2,3}$/;
Subtitle.SrtFile.prototype.fromTxt = function(txt) {
	let lines = txt.split("\r\n").join("\n").split("\n");
	let items = [];
	let last = { start: 0, end: 0, lines: [], length: 0 };
	let lastLength = 0;
	
	for (let i = 0; i < lines.length; i++) {
		let line = lines[i];
		if (line) {
			if (isFinite(line)) {
				// 숫자뿐인 대사줄 or 싱크 시작 불분명
				last.lines.push(line);
				last.length = Math.max(last.length, lastLength); // 기존 숫자뿐인 줄은 대사줄로 편입
				lastLength = last.lines.length;
				
			} else {
				if (Subtitle.SrtFile.REG_SRT_SYNC.test(line)) {
					// 새 싱크 시작
					last.lines.length = last.length;
					items.push(last = { start: 0, end: 0, lines: [], length: 0 });
					let syncs = line.split("-->");
					{	// 시작 싱크
						let times = syncs[0].trim().split(",").join(".").split(":");
						let start = Number(times[0]) * 60 + Number(times[1]);
						if (times.length > 2) {
							start = start * 60 + Number(times[2]);
						}
						last.start = Math.round(start * 1000);
					}
					{	// 종료 싱크
						let times = syncs[1].trim().split(",").join(".").split(":");
						let end = Number(times[0]) * 60 + Number(times[1]);
						if (times.length > 2) {
							end = end * 60 + Number(times[2]);
						}
						last.end = Math.round(end * 1000);
					}
					lastLength = 0;
					
				} else {
					// 대사줄 추가
					last.lines.push(line);
					last.length = last.lines.length;
				}
			}
		} else {
			// 공백줄 or 싱크 종료 불분명
			last.lines.push(line);
		}
	}
	last.lines.length = last.length;
	
	this.body = [];
	for (let i = 0; i < items.length; i++) {
		let item = items[i];
		this.body.push(new Subtitle.Srt(item.start, item.end, item.lines.join("\n")));
	}
	maruta = this;
	
	return this;
}

Subtitle.SrtFile.prototype.toSync = function() {
	let result = [];
	for (let i = 0; i < this.body.length; i++) {
		result.push(this.body[i].toSync());
	}
	return result;
}

Subtitle.SrtFile.prototype.fromSync = function(syncs) {
	this.body = [];
	for (let i = 0; i < syncs.length; i++) {
		this.body.push(new Subtitle.Srt().fromSync(syncs[i]));
	}
	return this;
}
