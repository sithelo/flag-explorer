import { Card, CardContent } from "@/components/ui/card";
import Image from "next/image";
import { Icon } from "@/components/ui/icon";
import { CountryInfo } from "@/types/country";
import { getDetailedViewData } from "@/use-cases/countries";
import { concatenateStrings } from "@/lib/flag";


export default async function Page({ params }: { params: { name: string } }) {
    const data: CountryInfo = await getDetailedViewData(params.name);
    
    return (
        <div className="px-10 flex-1">
            <h1 className="text-4xl font-bold text-center">{data.name} </h1>
          <div className="grid xl:grid-cols-2 grid-cols-1 gap-5">
            <div className="xl:col-span-2 col-span-1">
              <Card className="overflow-hidden">
                <div className=" h-[248px] w-full mb-6 ">
                  <Image
                    src={concatenateStrings(data.flag)}
                    alt=""
                    width={300}
                    height={300}
                    className=" w-full h-full  object-cover"
                  />
                </div>
                <CardContent>
                
                  <h5 className="inline-flex text-default-900">
                  <Icon icon="heroicons-outline:location-marker"
                          className="text-default-400 me-2 text-lg"
                        />
                  City :{data.countryDetails.capital}  
                  </h5>
                  <div className="text-default-700 mt-4 space-y-4">
                  <h5 className="inline-flex text-default-900">
                  <Icon icon="heroicons-outline:user"
                          className="text-default-400 me-2 text-lg"
                        />
                  Population :{data.countryDetails.population}  
                  </h5>
                  </div>
                </CardContent>
              </Card>
            </div>

          </div>
        </div>
        
    )
}