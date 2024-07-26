import { render, screen, waitFor } from "@testing-library/react";
import ButtonPort from "..";

describe("Create ButtonPort test", () => {
    it("render correctly ButtonPort component", async () => {
      const handlerOnChange = jest.fn();
      await render(
        <ButtonPort
        handlerOnClick={handlerOnChange}
        name={'test1'}
        tooltipDescription={'testTooltip'}
        />
      );
      await waitFor(() => {
        expect(screen.getByText("test1")).toBeInTheDocument();
        expect(screen.getByTitle(/testTooltip/i)).toBeInTheDocument();
      });
    });
  });
  