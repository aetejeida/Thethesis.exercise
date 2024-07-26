import React, { createContext, useContext, useReducer } from 'react';
import { getInitialState, stateReducer } from './appReducer';

export const AppContext = createContext();


export const AppContextComponent = ({children, data }) => {
    const defaultState = getInitialState();
    const appData = {
        ...defaultState,
        ...data
    }

    const [store, dispatch] = useReducer(stateReducer, appData);
    const state = { dispatch, store };

    return <AppContext.Provider value={{...state}}>{children}</AppContext.Provider>
}

export const withContext = (newProps = {}) => (ChildComponent) => (props) => (
    <AppContext.Consumer>
        {(context) => <ChildComponent {...context} {...newProps} {...props}/>}
    </AppContext.Consumer>
)

export const useAppContext = () => {
    const context = useContext(AppContext);

    if(!context){
        throw new Error('useAppContext cannot be rendered outside the AppContext.Provider Components');
    }
    return context;
}

