const baseUrl = 'https://localhost:7016';

export const getAll = () => {
    return fetch(`${baseUrl}/api/Car`)
        .then(res => res.json())
};

export const getOne = (id) => fetch(`${baseUrl}/Car/${id}`).then(res => res.json());