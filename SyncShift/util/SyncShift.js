var SyncShift = function(start, shift) {
	this.start = start;
	this.shift = shift;
}

SyncShift.CHECK_RANGE = 500;
SyncShift.MAX_POINT = 0.1;
SyncShift.WITH_KEYFRAME = false;

SyncShift.GetShiftsForRanges = function(origin, target, ranges, progress) {
    progress.Set(0);
	var shifts = [];
    for (var i = 0; i < ranges.length; i++) {
    	var range = ranges[i];
    	shifts = shifts.concat(SyncShift.GetShiftsForRange(origin, target, range, progress));
    }
    progress.Set(0);
    return shifts;
}
SyncShift.GetShiftsForRange = function(origin, target, range, progress) {
	progress.Set(range.start / origin.length);
	
	var shifts = [];
	var start = range.start;
	var shift = range.shift;
	var limitOfOrigin = Math.min(range.end, origin.length);

    var minPoint = null;
    var minAdd = 0;
    var doPlus = true, doMinus = true;
    
	for (var add = 0; (doPlus || doMinus)
	               && (start + shift + add < target.length - SyncShift.CHECK_RANGE)
	               && (start - shift + add < limitOfOrigin - SyncShift.CHECK_RANGE); add++) {
		if (doPlus) {
			if ((start + SyncShift.CHECK_RANGE < limitOfOrigin)
			 && (start + SyncShift.CHECK_RANGE + shift + add < target.length)) {
				var ratios = [];
				for (var i = 0; i < SyncShift.CHECK_RANGE; i++) {
					ratios.push(Math.log10((origin[start + i] + 0.000001) / (target[start + shift + add + i] + 0.000001)));
				}
				var point = new StDev(ratios);
				if (minPoint == null || point.value < minPoint.value) {
					// 오차가 기존값보다 작음
					console.log("오차가 기존값보다 작음(+)");
					minAdd = add;
					minPoint = point;
					console.log(point);
					if (point.value == 0.0) {
						console.log("완전히 일치: 정답 찾음");
						// 완전히 일치: 정답 찾음
						break;
					}
				} else if (point.value > minPoint.value * 20) {
					console.log("오차가 기존값에 비해 지나치게 큼(+)");
					// 오차가 기존값에 비해 지나치게 큼: 이미 정답을 찾았다고 간주
					console.log(point);
					doPlus = false;
				}
				
			} else {
				console.log("탐색 범위 벗어남(+)");
				doPlus = false;
			}
		}
		if (doMinus) {
			if ((start + SyncShift.CHECK_RANGE + shift + add < limitOfOrigin)
			 && (start + SyncShift.CHECK_RANGE + shift < target.length)) {
				if (start + shift - add < 0) {
					continue;
				}
				var ratios = [];
	            for (var i = 0; i < SyncShift.CHECK_RANGE; i++) {
	            	var ratio = Math.log10((origin[start + shift + i] + 0.000001) / (target[start + shift - add + i] + 0.000001));
            		ratios.push(ratio);
	            }
				var point = new StDev(ratios);
				if (minPoint == null || point.value < minPoint.value) {
					// 오차가 기존값보다 작음
					console.log("오차가 기존값보다 작음(-)");
					minAdd = -add;
					minPoint = point;
					console.log(point);
					if (point.value == 0.0) {
						// 완전히 일치: 정답 찾음
						console.log("완전히 일치: 정답 찾음");
						break;
					}
				} else if (point.value > minPoint.value * 20) {
					// 오차가 기존값에 비해 지나치게 큼: 이미 정답을 찾았다고 간주
					console.log("오차가 기존값에 비해 지나치게 큼(-)");
					console.log(point);
					doMinus = false;
				}
			} else {
				console.log("탐색 범위 벗어남(-)");
				doMinus = false;
			}
		}
	}
	
	if (minPoint > SyncShift.MAX_POINT) {
		console.log("찾지 못함");
		return shifts;
	}
	console.log("최종값");
	console.log(minPoint);
	shifts.push(new SyncShift(start, shift = (shift + minAdd)));
	
    // 현재 가중치가 어디까지 이어질지 구하기
    var limit = Math.max(minPoint.value * 12, 0.0001);
    var count = 0;
    var offset = start + 10;
    var v = 0;
    var oShift = 0
    var tShift = shift;
    if (shift < 0) {
    	offset -= shift;
    }
    
    while (offset + oShift < limitOfOrigin && offset + tShift < target.length) {
        v = Math.abs(Math.log10((origin[offset + oShift] + 0.000001) / (target[offset + tShift] + 0.000001)) - minPoint.avg);
        if (v > limit) {
            console.log(offset + ": " + v + " / " + limit);
            if (++count >= 5) break;
        } else if (count > 0) {
        	count = 0;
        }
        offset++;

        if (offset % 100 == 0) {
            progress.Set(offset / origin.length);
        }
    }
    console.log(v + " > " + limit);

    // 5초 이상 남았을 때만 나머지 범위 확인
    if (offset + 500 < range.end) {
        shifts = shifts.concat(SyncShift.GetShiftsForRange(origin, target, new Range(offset, range.end), progress));
    }
    
	return shifts;
}

/*
SyncShift.GetFrameShifts = function(
		oKfs
	,	tKfs
	,	sShifts
	)
{
    List<double> shiftOkfs = new List<double>();
    int index = 0;
    for (int i = 0; i < sShifts.length; i++)
    {
        int shift = sShifts[i].shift;
        int limit = (i + 1 < sShifts.length) ? sShifts[i + 1].start : int.MaxValue;

        for (; index < oKfs.length && oKfs[index] < limit; index++)
        {
            double v = oKfs[index] + shift;
            while (shiftOkfs.length > 0 && shiftOkfs[shiftOkfs.length - 1] > v)
                shiftOkfs.RemoveAt(shiftOkfs.length - 1);
            shiftOkfs.push(v);
        }
    }
    oKfs = shiftOkfs;

    List<SyncShift> fShifts = new List<SyncShift>();
    index = 0;
    double LIMIT = 0.1;
    foreach (double kf in oKfs)
    {
        console.log(kf);

        double maxMinus = -LIMIT;
        double minPlus = LIMIT;
        double t = 0;

        for (; index < tKfs.length && (t = tKfs[index] - kf) < 0; index++)
            maxMinus = t;

        if (index < tKfs.length)
            minPlus = tKfs[index] - kf;

        if (maxMinus > -LIMIT)
        {
            if (minPlus < LIMIT && minPlus < -maxMinus)
            {
                fShifts.push(new SyncShift((int)(1000 * kf), (int)(1000 * minPlus)));
            }
            else
            {
                fShifts.push(new SyncShift((int)(1000 * kf), (int)(1000 * maxMinus)));
            }
        }
        else
        {
            if (minPlus < LIMIT)
            {
                fShifts.push(new SyncShift((int)(1000 * kf), (int)(1000 * minPlus)));
            }
        }
    }
    SyncShift[] result = fShifts;
    fShifts = new List<SyncShift>();

    for (int i = 0; i < result.Length - 5; i++)
    {
        int max = (int)(1000 * LIMIT),
            min = (int)(-1000 * LIMIT),
            sum = 0;
        for (int j = 0; j < 5; j++)
        {
            int shift = result[j].shift;
            sum += shift;
            max = Math.max(max, shift);
            min = Math.min(min, shift);
        }
        fShifts.push(new SyncShift(result[i + 2].start, ((sum - min - max) / 3)));
    }
    if (fShifts.length == 0)
        fShifts.push(new SyncShift(0, 0));

    return fShifts;
}
*/

function StDev(values=[]) {
	var sum = 0;
	var pSum = 0;
	
	for (var i = 0; i < values.length; i++) {
		var value = values[i];
		var pow = value * value;
		sum += value;
		pSum += pow;
	}
	
	this.avg = sum / values.length;
	this.value = Math.sqrt((pSum / values.length) - (this.avg * this.avg));
}