import React from 'react';
import { render, screen, waitFor } from '@testing-library/react';
import '@testing-library/jest-dom';
import FlagGrid from '../components/flag-grid';
import { useParamsStore } from '@/hooks/use-params-store';
import { getAll } from '@/use-cases/countries';
import EmptyFilter from '@/components/empty-filter';

jest.mock('@/hooks/use-params-store', () => ({
    useParamsStore: jest.fn(),
}));

jest.mock('@/use-cases/countries', () => ({
    getAll: jest.fn(),
}));

jest.mock('@/components/empty-filter', () => jest.fn(() => <div>Empty Filter</div>));

jest.mock('../components/flag-card', () => jest.fn(({ country }) => <div>{country.name}</div>));

describe('FlagGrid Component', () => {
    const mockSetFlags = jest.fn();

    beforeEach(() => {
        jest.clearAllMocks();
        (useParamsStore as unknown as jest.Mock).mockReturnValue({
            flags: [],
            setFlags: mockSetFlags,
        });
    });

    it('renders loading state initially', () => {
        render(<FlagGrid />);
        expect(screen.getByText('Loading...')).toBeInTheDocument();
    });

    it('renders EmptyFilter when no flags are available', async () => {
        (getAll as jest.Mock).mockResolvedValueOnce([]);
        render(<FlagGrid />);

        await waitFor(() => expect(mockSetFlags).toHaveBeenCalledWith([]));
        expect(screen.getByText('Empty Filter')).toBeInTheDocument();
    });

    it('renders FlagCard components when flags are available', async () => {
        const mockFlags = [{ name: 'Country1' }, { name: 'Country2' }];
        (getAll as unknown as jest.Mock).mockResolvedValueOnce(mockFlags);

        (useParamsStore as unknown as jest.Mock).mockReturnValue({
            flags: mockFlags,
            setFlags: mockSetFlags,
        });

        render(<FlagGrid />);

        await waitFor(() => expect(mockSetFlags).toHaveBeenCalledWith(mockFlags));
        expect(screen.getByText('Country1')).toBeInTheDocument();
        expect(screen.getByText('Country2')).toBeInTheDocument();
    });

    it('calls getAll with the correct URL', async () => {
        const mockFlags = [{ name: 'Country1' }];
        (getAll as jest.Mock).mockResolvedValueOnce(mockFlags);

        render(<FlagGrid />);

        await waitFor(() => expect(getAll).toHaveBeenCalledWith('/api/v1/countries'));
    });

    it('sets loading to false after data is fetched', async () => {
        const mockFlags = [{ name: 'Country1' }];
        (getAll as jest.Mock).mockResolvedValueOnce(mockFlags);

        render(<FlagGrid />);

        await waitFor(() => expect(mockSetFlags).toHaveBeenCalledWith(mockFlags));
        expect(screen.queryByText('Loading...')).not.toBeInTheDocument();
    });

    it('renders the correct number of FlagCard components', async () => {
        const mockFlags = [
            { name: 'Country1' },
            { name: 'Country2' },
            { name: 'Country3' },
        ];
        (getAll as jest.Mock).mockResolvedValueOnce(mockFlags);

        (useParamsStore as unknown as jest.Mock).mockImplementation((selector) =>
            selector({
                flags: mockFlags,
                setFlags: mockSetFlags,
            })
        );

        render(<FlagGrid />);

        await waitFor(() => expect(mockSetFlags).toHaveBeenCalledWith(mockFlags));
        expect(screen.getAllByText(/Country/)).toHaveLength(mockFlags.length);
    });
});