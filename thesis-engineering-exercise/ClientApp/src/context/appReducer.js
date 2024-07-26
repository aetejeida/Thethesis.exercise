import ACTIONS from "./appActions";

export const getInitialState = () => ({});

export const stateReducer = (state, action) => {
    switch(action.type) {
        case ACTIONS.UPDATE_STATE: {
            return {
                ...state,
                ...action.data
            }
        }
        case ACTIONS.RESET_STATE: {
            return getInitialState();
        }
        default:
            return state;
    }
}