﻿using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace CardGame.Card.Controllers
{
    public class ImageDownloaderController
    {
        public async UniTask<Texture2D> DownloadImageAsync(string uri, CancellationToken cancellationToken)
        {
            using var www = UnityWebRequestTexture.GetTexture(uri);
        
            await www.SendWebRequest().WithCancellation(cancellationToken);
        
            return www.result == UnityWebRequest.Result.Success ? DownloadHandlerTexture.GetContent(www) : null;
        }
    }
}