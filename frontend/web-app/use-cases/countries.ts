'use server';


import { httpWrapper } from '@/data-access/http-wrapper';
import {Country, CountryInfo} from '@/types/country';

export async function getAll(query: string): Promise<Country[]> {
    return await httpWrapper.get(query)
}

export async function getDetailedViewData(name: string): Promise<CountryInfo> {
    return await httpWrapper.getByName(`api/v1/countries/${name}`)
}