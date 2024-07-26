import { render, screen, waitFor } from "@testing-library/react";
import React from "react";
import Select from "..";

describe("Create Select test", () => {
  it("render correctly select component", async () => {
    const handlerOnChange = jest.fn();
    await render(
      <Select
        className={"test"}
        defaultValue={1}
        name={"test_name"}
        handlerOnChange={handlerOnChange}
        handlerOnClick={handlerOnChange}
        options={[
          { id: 1, name: "test1" },
          { id: 2, name: "test2" },
          { id: 3, name: "test3" },
        ]}
      />
    );
    await waitFor(() => {
      expect(screen.getByText("test1")).toBeInTheDocument();
      expect(screen.getByText("test2")).toBeInTheDocument();
      expect(screen.getByText("test3")).toBeInTheDocument();
    });
  });
});
