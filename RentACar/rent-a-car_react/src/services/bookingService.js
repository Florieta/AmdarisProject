const baseUrl = 'https://localhost:7016/api';

export const getAllBookigs = (renterId) => {
    return fetch(`${baseUrl}/Orders/"${renterId}"`)
        .then(res => res.json())
}