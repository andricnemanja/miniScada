using System;
using System.Threading.Tasks;
using NModbus;

namespace ModbusServiceLibrary.Modbus.ModbusMaster
{
	public sealed class NullModbusMaster : IModbusMaster
	{
		public IModbusTransport Transport => throw new InvalidOperationException();

		public void Dispose()
		{
			throw new InvalidOperationException();
		}

		public TResponse ExecuteCustomMessage<TResponse>(IModbusMessage request) where TResponse : IModbusMessage, new()
		{
			throw new InvalidOperationException();
		}

		public bool[] ReadCoils(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
		{
			throw new InvalidOperationException();
		}

		public Task<bool[]> ReadCoilsAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
		{
			throw new InvalidOperationException();
		}

		public ushort[] ReadHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
		{
			throw new InvalidOperationException();
		}

		public Task<ushort[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
		{
			throw new InvalidOperationException();
		}

		public ushort[] ReadInputRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
		{
			throw new InvalidOperationException();
		}

		public Task<ushort[]> ReadInputRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
		{
			throw new InvalidOperationException();
		}

		public bool[] ReadInputs(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
		{
			throw new InvalidOperationException();
		}

		public Task<bool[]> ReadInputsAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
		{
			throw new InvalidOperationException();
		}

		public ushort[] ReadWriteMultipleRegisters(byte slaveAddress, ushort startReadAddress, ushort numberOfPointsToRead, ushort startWriteAddress, ushort[] writeData)
		{
			throw new InvalidOperationException();
		}

		public Task<ushort[]> ReadWriteMultipleRegistersAsync(byte slaveAddress, ushort startReadAddress, ushort numberOfPointsToRead, ushort startWriteAddress, ushort[] writeData)
		{
			throw new InvalidOperationException();
		}

		public void WriteFileRecord(byte slaveAdress, ushort fileNumber, ushort startingAddress, byte[] data)
		{
			throw new InvalidOperationException();
		}

		public void WriteMultipleCoils(byte slaveAddress, ushort startAddress, bool[] data)
		{
			throw new InvalidOperationException();
		}

		public Task WriteMultipleCoilsAsync(byte slaveAddress, ushort startAddress, bool[] data)
		{
			throw new InvalidOperationException();
		}

		public void WriteMultipleRegisters(byte slaveAddress, ushort startAddress, ushort[] data)
		{
			throw new InvalidOperationException();
		}

		public Task WriteMultipleRegistersAsync(byte slaveAddress, ushort startAddress, ushort[] data)
		{
			throw new InvalidOperationException();
		}

		public void WriteSingleCoil(byte slaveAddress, ushort coilAddress, bool value)
		{
			throw new InvalidOperationException();
		}

		public Task WriteSingleCoilAsync(byte slaveAddress, ushort coilAddress, bool value)
		{
			throw new InvalidOperationException();
		}

		public void WriteSingleRegister(byte slaveAddress, ushort registerAddress, ushort value)
		{
			throw new InvalidOperationException();
		}

		public Task WriteSingleRegisterAsync(byte slaveAddress, ushort registerAddress, ushort value)
		{
			throw new InvalidOperationException();
		}
	}
}
