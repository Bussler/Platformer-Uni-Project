using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularBuffer : MonoBehaviour {

    
        private TRObject[] list;
        private int end;
        private int start;
        private int size;
        public CircularBuffer(int _size)
        {
            size = _size;
            list = new TRObject[size];
            start = 0;
            end = 0;
        }
        public void Push(TRObject obj)
        {
            if ((end + 1) % size == start)
                start = (start + 1) % size;
            list[end] = obj;
            end = (end + 1) % size;
        }
        public TRObject Pop()
        {
            if (end != start)
            {
                end = (end - 1 + size) % size;
                return list[end];
            }
            return null;
        }
        // You can use this function to clear the CircularBuffer,
        // e.g. when reaching a checkpoint
        public void Clear()
        {
            for (int i = 0; i < size; i++)
                list[i] = null;
            start = end = 0;
        }
        public int Count
        {
            get { return (end - start + size) % size; }
        }
    }

