/*
public class StreamAttr
{
    public string type;
    public string language;
    public Dictionary<string, string> metadata = new Dictionary<string, string>();
}
*/	
function VideoInfo(file, progress) {
	this.file = file;
    this.duration = 0;
    this.streams = [];
    this.length = 0;
	if (progress) {
		this.progress = progress;
		this.isSkf = false;
	} else {
		this.progress = null;
		this.isSkf = true;
	}

    this.audioTrackIndexes = [];
    this.audioTrackIndex = 0;
    this.sfs = null;
    this.kfs = null;
}

VideoInfo.prototype.RefreshInfo = function(afterRefreshInfo) {
    this.RefreshVideoInfo();
    this.RefreshVideoLength();
    if (afterRefreshInfo) {
    	afterRefreshInfo(this);
    }
}

/*
VideoInfo.Process GetProcess = function(string exe) {
    Process proc = new Process();
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.CreateNoWindow = true;
    proc.StartInfo.RedirectStandardOutput = true;
    proc.StartInfo.FileName = Path.Combine(exePath, exe);
    return proc;
}
*/

VideoInfo.prototype.RefreshVideoInfo = function() {
	/*
    Process proc = GetProcess("ffprobe.exe");
    proc.StartInfo.Arguments = "\"" + path + "\"";
    proc.StartInfo.RedirectStandardError = true;
    proc.Start();

    StreamAttr lastStream = null;
    bool isMetadata = false;
    string[] lines = proc.StandardError.ReadToEnd().Split(new char[] { '\n', '\r' });
    foreach (string line in lines)
    {
        if (line.Trim().Length == 0) continue;
        if (lastStream != null && line.Equals("    Metadata:"))
        {
            isMetadata = true;
            continue;
        }
        if (lastStream != null && isMetadata)
        {
            string pattern = "^      (.*): (.*)$";
            System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(line, pattern);
            if (m.Success)
            {
                System.Text.RegularExpressions.GroupCollection groups = m.Groups;
                lastStream.metadata[groups[1].Value.Trim()] = groups[2].Value.Trim();
                continue;
            }
            else
            {
                isMetadata = false;
            }
        }
        if (line.StartsWith("  Duration: "))
        {
            string dur = line.Substring(12, line.IndexOf(',', 12) - 12);
            string[] vs = dur.Split(':');

            double v = 0;
            for (int i = 0; i < vs.Length; i++)
            {
                v = v * 60 + Convert.ToDouble(vs[i]);
            }
            duration = (int)(v * 1000);
            //Console.WriteLine("duration: {0}", duration);
        }
        else if (line.StartsWith("    Stream #"))
        {
            string pattern = "Stream #[0-9]+:[0-9]+\\((.*)\\): (.*): ";
            System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(line, pattern);
            System.Text.RegularExpressions.GroupCollection groups = m.Groups;
            streams.Add(lastStream = new StreamAttr()
            {   type = groups[2].Value.ToLower()
              , language = groups[1].Value
            });
        }
        else if (lastStream != null && line.StartsWith("      title           : "))
        {
            //lastStream.metadata["title"] = line.Substring(24);
        }
    }
    proc.Close();
    */
}

VideoInfo.prototype.RefreshVideoLength = function() {
	/*
    Process proc = GetProcess("ffprobe.exe");
    proc.StartInfo.Arguments = "-hide_banner -show_format -show_streams -pretty \"" + path + "\"";
    proc.Start();
    string[] lines = proc.StandardOutput.ReadToEnd().Split(new char[] { '\n', '\r' });
    foreach (string line in lines)
    {
        if (line.ToUpper().IndexOf("DURATION=") < 0) continue;

        int index = line.IndexOf("=");
        if (index < 0) continue;

        string[] vs = line.Substring(index + 1).Split(':');
        if (vs.Length == 1) continue;

        double v = 0;
        for (int i = 0; i < vs.Length; i++)
        {
            v = v * 60 + Convert.ToDouble(vs[i]);
        }
        return length = (int)(v * 1000);
    }
    proc.Close();

    return length = 10000000;
    */
}

VideoInfo.prototype.RefreshSkf = function() {
    if (this.isSkf) {
        this.LoadSkf();
    } else {
    	this.GetSfs();
    	this.GetKfs();
    }
}

VideoInfo.prototype.GetSfs = function() {
    if (this.sfs != null) {
        return this.sfs;
    }
    if (this.isSkf) {
    	return null;
    }

	/*
    int size = 0;
    {
        StreamAttr audioStream = streams[audioTrackIndex];
        string dur = null;
        try
        {
            dur = audioStream.metadata["DURATION"];
        }
        catch (Exception)
        {
            dur = audioStream.metadata["DURATION-eng"];
        }
        string[] vs = dur.Split(':');

        double v = 0;
        for (int i = 0; i < vs.Length; i++)
        {
            v = v * 60 + Convert.ToDouble(vs[i]);
        }

        size = (int)(v * 1000);
    }

    sfs = new List<double>();

    Process proc = GetProcess("ffmpeg.exe");
    proc.StartInfo.Arguments = "-i \"" + path + "\" -vn -ar 44100 -ac " + audioTrackIndex + " -f f32le -";
    proc.StartInfo.RedirectStandardError = true;
    proc.ErrorDataReceived += new DataReceivedEventHandler(Proc_ErrorDataReceived);
    proc.Start();
    proc.BeginErrorReadLine();

    Stream stream = proc.StandardOutput.BaseStream;

    int didread;
    int offset = 0;
    byte[] buffer = new byte[sizeof(float) * (1024 + 1)];

    int length, residual_length;

    int count = 0;
    double sum = 0;

    progress.Set(0);

    double ratio = withKeyframe ? 0.3 : 1;

    while ((didread = stream.Read(buffer, offset, sizeof(float) * 1024)) != 0)
    {
        length = offset + didread;
        residual_length = length % sizeof(float);

        length -= residual_length;

        for (int index = 0; index < length; index += sizeof(float))
        {
            float value = BitConverter.ToSingle(buffer, index);
            sum += Math.Abs(value);

            if (++count % 441 == 0)
            {
                sfs.Add(sum / count);
                sum = 0;
                if (count % 441000 == 0)
                    progress.Set(ratio * (count / (size * 44.1)));
            }
        }
    }
    proc.Close();

    progress.Set(0.3);

    return sfs;
    */
	return [];
}
VideoInfo.prototype.GetKfs = function() {
    if (this.kfs != null) {
        return this.kfs;
    }
    if (this.isSkf) {
    	return null;
    }

	/*
    kfs = new List<double>();

    if (withKeyframe)
    {
    	Process proc = GetProcess("ffmpeg.exe");
        proc.StartInfo.Arguments = "-loglevel error -skip_frame nokey -select_streams v:0 -show_entries frame=pkt_pts_time -of csv=print_section=0 \"" + path + "\"";
        proc.StartInfo.RedirectStandardError = true;
        proc.ErrorDataReceived += new DataReceivedEventHandler(Proc_ErrorDataReceived);
        proc.Start();
        proc.BeginErrorReadLine();

        progress.Set(0.3);

        StreamReader sr = new StreamReader(proc.StandardOutput.BaseStream);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            try
            {
                double time = double.Parse(line);
                Console.WriteLine(time);
                kfs.Add(time);
                if (true)
                    progress.Set(0.3 + (0.7 * (time * 1000 / length)));
            }
            catch (Exception) { }
        }
        proc.Close();

        progress.Set(1);
    }
	
    return kfs;
    */
	return [];
}

VideoInfo.prototype.SaveSkf = function() {
	/*
    int length = 0;

    string skfPath = path.Substring(0, path.Length - new FileInfo(path).Extension.Length) + ".skf";

    byte[] buffer;
    FileStream fs = new FileStream(skfPath, FileMode.Create);

    buffer = BitConverter.GetBytes(sfs.Count);
    fs.Write(buffer, 0, buffer.Length);
    length += buffer.Length;

    buffer = BitConverter.GetBytes(kfs.Count);
    fs.Write(buffer, 0, buffer.Length);
    length += buffer.Length;

    foreach (double sf in sfs)
    {
        buffer = BitConverter.GetBytes(sf);
        fs.Write(buffer, 0, buffer.Length);
        length += buffer.Length;
    }

    foreach (double kf in kfs)
    {
        buffer = BitConverter.GetBytes(kf);
        fs.Write(buffer, 0, buffer.Length);
        length += buffer.Length;
    }

    fs.Close();

    //Console.Write("save length: " + length);

    return length;
    */
    return 0;
}
VideoInfo.prototype.LoadSkf = function() {
	/*
    sfs = new List<double>();
    kfs = new List<double>();

    FileStream fs = new FileStream(path, FileMode.Open);

    int didread;
    byte[] buffer = new byte[sizeof(double) * (1024 + 1)];

    int length, residual_length;

    fs.Read(buffer, 0, sizeof(int) * 2);
    int sfsLength = BitConverter.ToInt32(buffer, 0);
    int kfsLength = BitConverter.ToInt32(buffer, sizeof(int));

    int count = 0;

    while ((didread = fs.Read(buffer, 0, sizeof(double) * 1024)) != 0)
    {
        length = didread;
        residual_length = length % sizeof(double);

        length -= residual_length;

        for (int index = 0; index < length; index += sizeof(double))
        {
            double value = BitConverter.ToDouble(buffer, index);
            if (count < sfsLength)
                sfs.Add(value);
            else if (count < sfsLength + kfsLength)
                kfs.Add(value);
            else
            {

            }
            count++;
        }
    }

    fs.Close();
    
    //Console.WriteLine(sfs.Count + "/" + sfsLength + ", " + kfs.Count + "/" + kfsLength);
	*/
	
	var sfs = this.sfs = [];
	var kfs = this.kfs = [];
	
	var fr = new FileReader();
	fr.onload = function(e) {
		var buffer = e.target.result;
		console.log(buffer);
		
		var info = new Int32Array(buffer);
	    var sfsLength = info[0];
	    var kfsLength = info[1];
	    
	    var view = new DataView(buffer.slice(8, 8 + (sfsLength * 8)));
	    for (var i = 0; i < sfsLength; i++) {
	    	sfs.push(view.getFloat64(i * 8, true));
	    }
	    view = new DataView(buffer.slice(8 + (sfsLength * 8), 8 + ((sfsLength + kfsLength) * 8)));
	    for (var i = 0; i < kfsLength; i++) {
	    	kfs.push(view.getFloat64((sfsLength + i) * 8));
	    }
	    console.log(sfs.join("\n"));
	}
	fr.readAsArrayBuffer(this.file);
}
