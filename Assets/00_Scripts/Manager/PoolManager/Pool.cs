using System;
using System.Collections;
using System.Collections.Generic;

public class Pool<T> : IEnumerable where T : IResettable
{
    public Pool(IFactory<T> factory) : this(factory, 5) { }

    public Pool(IFactory<T> factory, int poolSize)
    {
        this.factory = factory;
        for (int i = 0; i < poolSize; i++)
        {
            Create();
        }
    }

    ///<summary>members : Ǯ �ȿ� ������ ��� �����</summary>        
    public List<T> members = new List<T>();

    ///<summary>unavailable : �̹� ������� �����</summary>        
    public HashSet<T> unavailable = new HashSet<T>();

    ///<summary>factory : �� ����� �����ϱ� ���� �������̽�</summary> 
    IFactory<T> factory;

    /// <summary>�� ��� ����</summary>
    /// <returns>T</returns>
    T Create()
    {
        T member = factory.Create();
        members.Add(member);
        return member;
    }

    /// <summary>����� �����ų� Ȥ�� ���� ����.</summary>
    /// <returns>T</returns>        
    public T Allocate()
    {
        for (int i = 0; i < members.Count; i++)
        {
            if (!unavailable.Contains(members[i]))
            {
                unavailable.Add(members[i]);
                return members[i];
            }
        }

        T newMembers = Create();
        unavailable.Add(newMembers);
        return newMembers;
    }

    /// <summary>
    /// ����� �ٽ� ��� �����ϵ��� Ǯ�� �������´�. ����� ���� ��� ����� �߰�.
    /// </summary>
    /// <param name="member">�������� Ǯ�� ���</param>
    public void Release(T member)
    {
        member.Reset();
        if (unavailable.Contains(member))
        {
            unavailable.Remove(member);
        }
        else
        {
            members.Add(member);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator<T>)members.GetEnumerator();
    }

    public int GetUsedCount()
    {
        return unavailable.Count;
    }
}
