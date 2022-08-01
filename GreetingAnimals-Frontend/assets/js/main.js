export const adminAPI= 'https://localhost:44346/api/Admins';
export const itemAPI= 'https://localhost:44346/api/Items';
export const playerAPI= 'https://localhost:44346/api/Players';

/// <summary>
/// post data into API
/// </summary>
/// <param name="url"></param>
/// <param name="data"></param>
/// <returns>response.json()</returns>
export async function postData(url = '', data = {}) {
    const response = await fetch(url, {
        method: 'POST',
        headers: {
        'Content-Type': 'application/json'
        },
        body: JSON.stringify(data) 
    });
    return response.json(); 
}

/// <summary>
/// put data in API
/// </summary>
/// <param name="url"></param>
/// <param name="data"></param>
/// <returns>response.json()</returns>
export async function putData(url = '', data = {}) {
    const response = await fetch(url, {
        method: 'PUT',
        headers: {
        'Content-Type': 'application/json'
        },
        body: JSON.stringify(data) 
    });
    return response.json();
}

/// <summary>
/// delete data from API
/// </summary>
/// <param name="url"></param>
/// <param name="data"></param>
/// <returns>response.json()</returns>
export function dellObject(id, adminDeleteAPI){
    var option ={
        method: 'DELETE',
        header:{
            'Content-Type' : 'application/json'
        },
    };
    fetch(adminDeleteAPI+'/'+id, option)
        .then(function(response) {
            response.json();
        });
    location.reload();
    alert("successful delete!");
}