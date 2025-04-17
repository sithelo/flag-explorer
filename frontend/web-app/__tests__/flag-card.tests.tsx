import '@testing-library/jest-dom'
import React from 'react';
import { render, screen } from '@testing-library/react';
import FlagCard from '../components/flag-card';

import { Country } from '@/types/country';

describe('FlagCard', () => {
    const mockCountry = {
        name: 'Japan',
        flag: 'jp',
    };
    const mockCountryEmpty = {
        name: '',
        flag: '',
    };
    
    it('renders the flag image with correct alt text', () => {
        render(<FlagCard country={mockCountryEmpty}  />);

        const flagImage = screen.getByRole('img', {   });

        expect(flagImage).toBeInTheDocument();
        expect(flagImage).toHaveAttribute('alt', 'image of flag');
    });

    it('renders the country name', () => {
        render(<FlagCard country={mockCountry}  />);

        const countryName = screen.getByText(/japan/i);

        expect(countryName).toBeInTheDocument();
    });

    it('handles missing flagUrl gracefully', () => {
        render(<FlagCard country={mockCountryEmpty}  />);

        const flagImage = screen.getByRole('img', { name: /flag/i });

        expect(flagImage).toHaveAttribute('src', 'https://flagcdn.com/.svg');
    });
});