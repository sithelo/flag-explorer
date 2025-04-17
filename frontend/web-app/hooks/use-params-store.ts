import { Country, CountryInfo } from "@/types/country"
import { create } from "zustand"


type State = {
    searchTerm: string
    searchValue: string
    flags: Country[]
    countryInfo?: CountryInfo
}

type Actions = {
    setSearchValue: (value: string) => void
    setParams: (params: Partial<State>) => void
    reset: () => void
    setFlags: (data: Country[]) => void
}

const initialState: State = {
    searchTerm: '',
    searchValue: '',
    flags: [],
    countryInfo: undefined
}

export const useParamsStore = create<State & Actions>()((set) => ({
    ...initialState,

    setParams: (newParams: Partial<State>) => {
        set((state) =>  {
            return {...state, ...newParams, pageNumber: 1}
        }
        )
    },

    reset: () => {
        set(initialState)
    },

    setSearchValue: (value: string) => {
        set({searchValue: value})
    },
    
    setFlags: (data: Country[]) => {
        set(() => ({
            flags: data
        }))
    },
}))