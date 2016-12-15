# vimeo-downloader
Asynchronous .NET library for downloading Vimeo video's

How to
=============

	string videoId = "193970500";

	Video video = await Vimeo.Download(videoId);

	//or specify the preffered quality

	Video video = await Vimeo.Download(videoId, VideoQuality.High);