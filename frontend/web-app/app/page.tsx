import FlagGrid from "@/components/flag-grid";

export default function Home() {

  return (
    <div className="py-24 px-10 flex min-h-[80dvh] items-center justify-center mx-auto">
      <div className="mx-auto space-y-6">
        <h1 className="text-4xl font-bold text-center">Countries</h1>
        <FlagGrid/>
      </div>
    </div>
  )
}
