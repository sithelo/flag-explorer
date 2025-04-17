import React from 'react'
import Image from 'next/image';
import { Country } from '@/types/country';
import Link from 'next/link';
import { Card, CardContent } from '@/components/ui/card';

type Props = {
    country: Country;
}

export default function FlagCard({ country }: Props) {
    const flagcdn = `https://flagcdn.com/${country.flag}.svg`.toLowerCase();
    return (
        <>    
        
        <Card className="overflow-hidden">
              <div className=" h-[248px] w-full mb-6 ">
              <Link href={`/countries/details/${country.name}`}>
                <Image
                  src={flagcdn}
                  alt="image of flag"
                  className="w-full h-full  object-cover"
                  width={300}
                  height={300}
                /></Link>
              </div>
              <CardContent>
                <div className="flex justify-between mb-4">
                  <div>
                    <h5 className=" text-default-900">
                      <Link href={`/countries/details/${country.name}`}>{country.name}</Link>
                    </h5>
                  </div>
                  
                </div>

                <div className="text-default-700 mt-4">
                  <div className="mt-4 space-x-4 rtl:space-x-reverse">
                    <Link href={`/countries/details/${country.name}`} className="text-sm font-medium underline">
                      Read more
                    </Link>
                  </div>
                </div>
              </CardContent>
            </Card>
        
        </>
    )
}