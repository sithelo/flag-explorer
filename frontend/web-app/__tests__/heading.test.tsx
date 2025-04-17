import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom';
import Heading from '../components/heading';

describe('Heading Component', () => {
    it('renders the title correctly', () => {
        render(<Heading title="Test Title" />);
        expect(screen.getByText('Test Title')).toBeInTheDocument();
    });

    it('renders the subtitle when provided', () => {
        render(<Heading title="Test Title" subtitle="Test Subtitle" />);
        expect(screen.getByText('Test Subtitle')).toBeInTheDocument();
    });

    it('does not render the subtitle when not provided', () => {
        render(<Heading title="Test Title" />);
        expect(screen.queryByText('Test Subtitle')).not.toBeInTheDocument();
    });

    it('applies text-center class when center prop is true', () => {
        const { container } = render(<Heading title="Test Title" center />);
        expect(container.firstChild).toHaveClass('text-center');
    });

    it('applies text-start class when center prop is false or undefined', () => {
        const { container } = render(<Heading title="Test Title" />);
        expect(container.firstChild).toHaveClass('text-start');
    });
});