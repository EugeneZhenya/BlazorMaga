function my_function(message) {
    console.log("from utilities " + message);
}

function dotnetStaticInvocation() {
    DotNet.invokeMethodAsync('BlazorMaga.Client', 'GetCountAsync')
        .then(result => {
            console.log("Result from static method: " + result);
        })
        .catch(error => {
            console.error("Error invoking static method: " + error);
        });
}

function dotnetInstanceInvocation(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCount");
}
