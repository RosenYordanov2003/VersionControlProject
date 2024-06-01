const baseUrl = 'https://localhost:7185/api/auth/register';

export async function register(object) {
    console.log(object);
    const request = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(object)
    })

    const response = await request.json();

    return response;
}