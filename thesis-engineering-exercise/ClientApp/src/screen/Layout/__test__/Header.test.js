import { cleanup, render, screen } from "@testing-library/react";
import Header from "../Header";

describe("Testing Layout Component", () => {
    afterEach(() => {
      cleanup();
    });

    it("render appropriately", () => {
      render(<Header/>);
      expect(screen.getByText(/Computer Catalog/i)).toBeInTheDocument();
    });

    it("show correct test in header", () => {
        render(<Header/>);
        expect(screen.getByText(/Fill out the table below based on your database design/i)).toBeInTheDocument();
      });

    
  });
  