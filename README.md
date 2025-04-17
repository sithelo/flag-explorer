# Flag Explorer

What's included in this solution?

- SharedKernel project with common Domain-Driven Design abstractions.
- Domain layer with a sample entity.
- Application layer with abstractions for:
    - CQRS
    - Caching
    - Cross-cutting concerns (logging, caching, validation)
- Infrastructure layer with:
    - SQL (Dapper), EF Core, Caching, Repositories
- Seq for searching and analyzing structured logs
    - Seq is available at http://localhost:8081 by default
- Testing projects
    - Unit testing
    - Integration testing
    - Functional testing
    - Architecture testing

- Nextjs frontend
    - Built with shadcn/ui
    - Tailwindcss
    - Zustand as state management tool
    - Jest for unit testing
    - Reactjs 
  
- How to run the application
     - 1st option if you have docker install is to use docker compose up
     - 2nd option is to run each solution by
          - Go to the root of the frontend and first run ```pnpm i``` then when the packages have install run ```pnpm run dev```.
          - To run the ```pnpm run test```
          - depending on your machine one might need to change the api endpoint to fetch the countries (the flag images endpoint is still the same as per documentation)
          - The backend api is set to run on ```localhost:5000```. One needs to run a dockerized postgres database and the migration.
       
- Included is  a yaml file for 1) restoring 2) Building and 3) Testing 


