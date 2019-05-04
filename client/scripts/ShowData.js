$(document).ready(function(){

    function toDatetimeLocal(date) {
    var
        date = date,
        ten = function (i) {
        return (i < 10 ? '0' : '') + i;
        },
        YYYY = date.getFullYear(),
        MM = ten(date.getMonth() + 1),
        DD = ten(date.getDate()),
        HH = ten(date.getHours()),
        II = ten(date.getMinutes()),
        SS = ten(date.getSeconds())
    ;
    return YYYY + '-' + MM + '-' + DD + 'T' +
                HH + ':' + II + ':' + SS;
    };

    document.getElementById("showData").addEventListener("click", getData);
    document.getElementById("lastHour").addEventListener("click", setLastHour);
    document.getElementById("lastTwoHours").addEventListener("click", setLastTwoHours);
    document.getElementById("today").addEventListener("click", setToday);

    function removeChilds(container){
        while (container.firstChild) {
            container.removeChild(container.firstChild);
            
        }
        console.log("removed all");
    }

    async function getData() {
        let container = document.getElementById('tableBody');
        removeChilds(container);
        await getDataFromApi();

    }

    function getDataFromApi() {
        let dateTimeFrom = document.getElementById("fromDateTime").value;
        let dateTimeTo = document.getElementById("toDateTime").value;
        let queues = document.getElementById("queues").value;

        if (dateTimeFrom && dateTimeTo){
            
            
            let splitQueues = queues.split(",");
            console.log(queues);
            console.log(splitQueues);
            if (!splitQueues) {
                splitQueues = queues;
            }

            let url = 'https://localhost:44394/api/Data?from='+dateTimeFrom+'&to='+dateTimeTo;
            splitQueues.map(queue => {
                url = url + '&ids='+queue;
            });
            
            const param = {
                method: "GET",
                mode: "cors",
                cache: "no-cache",
                credentials: "same-origin",
                headers:{
                    "content-type":"application/json; charset=UTF-8"
                }
            }

            fetch(url, param)
                .then(data=>{return data.json()})
                .then(res=>{
                    res.map(r => {
                        console.log(r);

                        let container = document.getElementById('tableBody');

                        const row = document.createElement('tr');

                        const column = document.createElement('th');
                        column.setAttribute('scope', 'row');
                        column.innerHTML = r.csqName;

                        const column1 = document.createElement('td');
                        column1.setAttribute('scope', 'row');
                        column1.innerHTML = r.loggedinagents;

                        const column2 = document.createElement('td');
                        column2.setAttribute('scope', 'row');
                        column2.innerHTML = r.availableagents;

                        const column3 = document.createElement('td');
                        column3.setAttribute('scope', 'row');
                        column3.innerHTML = r.numberOfCalls;

                        const column4 = document.createElement('td');
                        column4.setAttribute('scope', 'row');
                        column4.innerHTML = r.numberOfhandledCalls;

                        const column5 = document.createElement('td');
                        column5.setAttribute('scope', 'row');
                        column5.innerHTML = r.numberOfAbandonedCalls;

                        row.appendChild(column);
                        row.appendChild(column1);
                        row.appendChild(column2);
                        row.appendChild(column3);
                        row.appendChild(column4);
                        row.appendChild(column5);

                        container.append(row);

                    })
                    
                });


        }else{

        }

    }


    function setLastHour() {
        var now = new Date();
        var hourBack = new Date();
        hourBack.setHours(hourBack.getHours()-1);

        document.getElementById("fromDateTime").value = toDatetimeLocal(hourBack);
        document.getElementById("toDateTime").value = toDatetimeLocal(now);
    }

    function setLastTwoHours() {
        var now = new Date();
        var twoHoursBack = new Date();
        twoHoursBack.setHours(twoHoursBack.getHours()-2);

        document.getElementById("fromDateTime").value = toDatetimeLocal(twoHoursBack);
        document.getElementById("toDateTime").value = toDatetimeLocal(now);
    }

    function setToday() {
        var now = new Date();
        var dayStart = new Date(now.getFullYear(), now.getMonth(), now.getDate());

        document.getElementById("fromDateTime").value = toDatetimeLocal(dayStart);
        document.getElementById("toDateTime").value = toDatetimeLocal(now);
    }


});

