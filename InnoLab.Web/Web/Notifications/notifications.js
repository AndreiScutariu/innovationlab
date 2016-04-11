var addSubscription = function (subscription) {
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "/users/add?id=" + subscription, false);
    xhttp.send();
    console.log('endpoint:', subscription);
};

var subscribe = function () {
    navigator.serviceWorker.ready.then(function (serviceWorkerRegistration) {
        serviceWorkerRegistration.pushManager.subscribe({ userVisibleOnly: true })
            .then(function (subscription) {
                return addSubscription(subscription.endpoint);
            })
            .catch(function (e) {
                if (Notification.permission === "denied") {
                    console.warn("Permission for Notifications was denied");
                } else {
                    console.error("Unable to subscribe to push.", e);
                }
            });
    });
};

var initialiseState = function () {
    if (!("showNotification" in ServiceWorkerRegistration.prototype)) {
        console.warn("Notifications aren't supported.");
        return;
    }

    if (Notification.permission === "denied") {
        console.warn("The user has blocked notifications.");
        return;
    }

    if (!("PushManager" in window)) {
        console.warn("Push messaging isn't supported.");
        return;
    }

    navigator.serviceWorker.ready.then(function (serviceWorkerRegistration) {
        serviceWorkerRegistration.pushManager.getSubscription()
          .then(function (subscription) {
              if (!subscription) {
                  return;
              }
              addSubscription(subscription.endpoint);
          })
          .catch(function (err) {
              console.warn("Error during getSubscription()", err);
          });
    });
};


window.addEventListener("load", function () {
    subscribe();

    if ("serviceWorker" in navigator) {
        navigator.serviceWorker.register("worker.js")
        .then(initialiseState);
    } else {
        console.warn("Service workers aren't supported in this browser.");
    }
});