﻿namespace ModbusServiceLibrary.SignalConverter
{
	public interface ISignalMapper
	{
		string ConvertDiscreteSignalValueToState(int mappingId, byte signalValue);
		double ConvertAnalogSignalToRealValue(int rtuId, double signalValue);
		int ConvertRealValueToAnalogSignalValue(int mappingId, double signalValue);
		byte ConvertStateToDiscreteSignalValue(int mappingId, string value);
	}
}