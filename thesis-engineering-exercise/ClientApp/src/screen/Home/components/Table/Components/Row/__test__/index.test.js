import { render, screen, waitFor } from "@testing-library/react";
import Row from "..";

describe("Create Row Component test", () => {
  it("render correctly Row Component Not Edit mode", async () => {
    await render(
      <table>
        <thead>
          <tr>
            <th>Test</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <Row isEditRow={0} index={1} value={"test1"} />
          </tr>
        </tbody>
      </table>
    );
    await waitFor(() => {
      expect(screen.getByText("test1")).toBeInTheDocument();
    });
  });

  it("render correctly Row Component Edit mode", async () => {
    await render(
      <table>
        <thead>
          <tr>
            <th>Test</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <Row
              isEditRow={1}
              index={1}
              formName={"test_select"}
              options={[
                { id: 1, name: "test1" },
                { id: 2, name: "test2" },
                { id: 3, name: "test3" },
              ]}
              defaultValue={1}
            />
          </tr>
        </tbody>
      </table>
    );
    await waitFor(() => {
      expect(screen.getByText("test1")).toBeInTheDocument();
    });
  });
});
