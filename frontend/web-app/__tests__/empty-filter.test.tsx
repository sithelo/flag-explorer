import { render, screen, fireEvent } from '@testing-library/react';
import '@testing-library/jest-dom';
import EmptyFilter from '@/components/empty-filter';


describe('EmptyFilter Component', () => {
    it('renders with default props', () => {
        render(<EmptyFilter />);
        expect(screen.getByText('No matches for this filter')).toBeInTheDocument();
        expect(screen.getByText('Try changing or resetting the filter')).toBeInTheDocument();
    });

    it('renders with custom title and subtitle', () => {
        render(<EmptyFilter title="Custom Title" subtitle="Custom Subtitle" />);
        expect(screen.getByText('Custom Title')).toBeInTheDocument();
        expect(screen.getByText('Custom Subtitle')).toBeInTheDocument();
    });

    it('does not show reset button when showReset is false', () => {
        render(<EmptyFilter showReset={false} />);
        expect(screen.queryByText('Remove filters')).not.toBeInTheDocument();
    });

    // it('shows reset button and calls reset function when clicked', () => {
    //     const mockReset = jest.fn();
    //     (useParamsStore as jest.Mock).mockReturnValue({ reset: mockReset });

    //     render(<EmptyFilter showReset={true} />);
    //     const resetButton = screen.getByText('Remove filters');
    //     expect(resetButton).toBeInTheDocument();

    //     fireEvent.click(resetButton);
    //     expect(mockReset).toHaveBeenCalledTimes(1);
    // });
});