# vimeo-downloader
Asynchronous .NET library for downloading Vimeo video's

How to
=============

	string videoId = "193970500";

	Video video = await Vimeo.Download(videoId);

	string path = @"c:\" + video.FileName;
	File.WriteAllBytes(path, video.Data);

	//or specify the preffered quality

	Video video = await Vimeo.Download(videoId, VideoQuality.High);

	string path = @"c:\" + video.FileName;
	File.WriteAllBytes(path, video.Data);