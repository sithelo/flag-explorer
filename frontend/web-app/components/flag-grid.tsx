'use client'

import React, { useEffect, useState } from 'react'
import FlagCard from './flag-card';


import { useShallow } from 'zustand/react/shallow';

import EmptyFilter from "@/components/empty-filter";
import { useParamsStore} from "@/hooks/use-params-store";
import { getAll } from '@/use-cases/countries';

export default function FlagGrid() {
    const [loading, setLoading] = useState(true);

    const data = useParamsStore(useShallow(state => ({
        flags: state.flags    })))

    const setData = useParamsStore(state => state.setFlags);

    const url = '/api/v1/countries';
    useEffect(() => {
        getAll(url).then(data => {
            setData(data);
            setLoading(false);
        })
    }, [url, setData])

    if (loading) return <h3>Loading...</h3>

    return (
        <>
            {data.flags.length === 0 ? (
                <EmptyFilter showReset />
            ) : (
                <>
                    <div className='grid grid-cols-4 gap-6'>
                        {data.flags.map((country) => (
                            <FlagCard key={country.name} country={country} />
                        ))}
                    </div>

                </>
            )}
        </>
    )
}