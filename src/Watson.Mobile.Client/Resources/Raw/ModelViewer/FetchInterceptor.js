// Fetch, which model-viewer uses, does not support loading documents through the file uri scheme.
// This will intercept fetch calls and replace it with a xhr request when the file uri scheme is used.

window.fetch = async (...args) => {
    const [request, config] = args;
    let response;
    if (request.url?.startsWith('file://')) {
        response = new Promise((resolve, reject) => {
            const xhr = new XMLHttpRequest();
            const url = decodeURI(request.url);
            xhr.open(request.method, url, true);
            xhr.responseType = 'arraybuffer';

            xhr.addEventListener('load', () => {
                resolve({
                    status: xhr.status,
                    url: url,
                    body: xhr.response,
                    arrayBuffer: () => xhr.response
                });
            }, false);
            xhr.addEventListener('error', (error) => reject(error), false);
            xhr.send();
        });
    }
    else {
        response = await originalFetch(request, config);
    }
    return response;
};