const baseUrl = 'https://localhost:7016';

export const login = async (userName, password) => {
    let res = await fetch(`${baseUrl}/api/Authentication/login`, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({ userName, password })
    });

    let jsonResult = await res.json();

    if (res.ok) {
        return jsonResult;
    } else {
        throw jsonResult.message;
    }
};

export const logout = (token) => {
    return fetch(`${baseUrl}/api/Authentication/logout`, {
        headers: {
            'X-Authorization': token,
        }
    })
};

export const getUser = () => {
    let username = localStorage.getItem('userName');

    return username;
};

export const isAuthenticated = () => {
    return Boolean(getUser())
};