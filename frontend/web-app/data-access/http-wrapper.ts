import {Country, CountryInfo} from "@/types/country";
import { promises as fs } from 'fs';

const baseUrl = process.env.API_URL || 'https://localhost:5000';

async function get(url: string): Promise<Country[]> {
    const requestOptions = {
        method: 'GET',
        headers: await getHeaders()
    }
    // const file = await fs.readFile(process.cwd() + '/data-access/countries.json', 'utf8');
    // const data = JSON.parse(file);
    // return data;
    // const response = await fetch('/data-access/countries.json');
    console.log('url', baseUrl + url);
    const response = await fetch(baseUrl + url, requestOptions);
    return handleResponse(response);
}

async function getByName(url: string): Promise<CountryInfo> {
    const requestOptions = {
        method: 'GET',
        headers: await getHeaders()
    }
    return {
        name: 'Japan',
        flag: 'jp',
        countryDetails: {
            name: 'Japan',
            capital: 'Tokyo',
            population: 126476461,
    }
    // const response = await fetch(baseUrl + url, requestOptions);
    // return handleResponse(response);
}}


async function getHeaders() {
    const headers = {
        'Content-type': 'application/json'
    } as any;

    return headers;
}

async function handleResponse(response: Response) {
    const text = await response.text();
    let data;
    try {
        data = JSON.parse(text);
        console.log(data);
        // eslint-disable-next-line @typescript-eslint/no-unused-vars
    } catch (error) {
        data = text;
    }

    if (response.ok) {
        return data || response.statusText;
    } else {
        const error = {
            status: response.status,
            message: typeof (data === 'string') ? data : response.statusText
        }
        return {error}
    }
}

export const httpWrapper = {
    get,
    getByName
}