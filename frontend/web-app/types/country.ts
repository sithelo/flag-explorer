export type Country = {
    name: string
    flag: string
}
export type CountryInfo = {
    name: string
    flag: string
    countryDetails: CountryDetail
}
export type CountryDetail = {
    name: string
    population: number
    capital: string
}